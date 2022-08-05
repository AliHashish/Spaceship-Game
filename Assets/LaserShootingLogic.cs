using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShootingLogic : MonoBehaviour, IGunType
{
    [SerializeField] private LayerMask layerMask;
    
    // public Transform firePoint;
    public LineRenderer laserLine;
    public GameObject onImpactEffect;
    public float laserWidth = 0.06f;
    public float laserMaxRange = 5f;
    public float damage = 0.1f;        // 5ly balk eno byedrab 100 mara fl sanya, fa kda damage = 100 * 0.1 = 10 fl sanya

    float distance;     // el msafa ma bein el player wl object elly et5abat
    // Start is called before the first frame update
    void Start()
    {
        laserLine.enabled = false;
        // Debug.Log("5lah false");
    }

    // Update is called once per frame
    void Update()
    {
        // StartCoroutine(la7za());         // Wait shwya
        // waitingTime = 0f;
    }

    public void Shoot()
    {
        laserLine.startWidth = laserWidth;
        laserLine.endWidth = laserWidth;
        // waitingTime = 1f;
        // Debug.Log(layerMask.ToString());
        RaycastHit2D hitObjectInfo = Physics2D.Raycast(this.GetComponent<Transform>().position, this.GetComponent<Transform>().right, Mathf.Infinity, layerMask);
        // 8albn m3naha lw el laser kamel fl etgah bta3o, hye5bat fy eih aw kda
        if (hitObjectInfo)          // 5abat 7aga
        {
            // Debug.Log(hitObjectInfo.EnemyInfo.health);
            // Debug.Log(hitObjectInfo.transform.GetComponent<EnemyInfo>().health);
            // Debug.Log(hitObjectInfo.transform.name);
            // Debug.Log(hitObjectInfo.transform.position);
            // Debug.Log(this.GetComponent<Transform>().position);
            
            distance = Distance(hitObjectInfo);     
            // Debug.Log(Distance(hitObjectInfo));

            // Debug.Log(firePoint.position);
            // h7sb b2a el distance ma bein el firePoint.position wl object elly et5abat
            // w lw hya as8r mn el max distance bta3t el laser, h5leeh ya5od damage wl kalam dh
            // lw la, msh hya5od damage. wl effect bta3t el laser hye5talef
            laserLine.SetPosition(0, this.GetComponent<Transform>().position);              // b5ly el starting point hya el this.GetComponent<Transform>()
            if (distance <= laserMaxRange)  // yb2a ersem 3ady mn el player lel object
            {
                laserLine.SetPosition(1, hitObjectInfo.point);          // b5ly el ending point hya el 7aga elly et5abatet
                
                // hena e3ml el particle effect wl damage
                GameObject effect = Instantiate(onImpactEffect, hitObjectInfo.point, Quaternion.identity);
                Destroy(effect, 0.41f);    // bn3ml destroy bs b3deeha b 0.41 seconds
                if (hitObjectInfo.transform.CompareTag("Enemy"))   // 5abat enemy, fa e3mlo damage
                {
                    // Debug.Log("bat7ere2 ya naaaaas");
                    if(hitObjectInfo.transform.GetComponent<ChargerMovement>())
                    {
                        hitObjectInfo.transform.GetComponent<ChargerMovement>().health -= damage;
                    }
                    else
                    {
                        hitObjectInfo.transform.GetComponent<EnemyInfo>().health -= damage;
                    }
                }
                else if (hitObjectInfo.transform.CompareTag("Destructables"))
                {
                    hitObjectInfo.transform.GetComponent<Destructable>().hitPoints -= 1f/50f;
                }
                // lw hzwd 7aga lel boss htb2a hena brdo
            }
            else
            {
                Debug.Log("3ada el max");
                laserLine.SetPosition(1, this.GetComponent<Transform>().position + this.GetComponent<Transform>().right * laserMaxRange);          // b5ly el ending point hya el max range
                // Instantiate(onImpactEffect, this.GetComponent<Transform>().position + this.GetComponent<Transform>().right * laserMaxRange, Quaternion.identity);
            }
            
            // Vector3 zeroVec = new Vector3(0f,0f,0f);
            // laserLine.SetPosition(0, zeroVec);              // b5ly el starting point hya el this.GetComponent<Transform>()
            // Vector2 posVec = new Vector2(0f,0f);
            // zeroVec = this.GetComponent<Transform>().position;
            // posVec.x = zeroVec.x;
            // posVec.y = zeroVec.y;
        }
        else        // m5abatsh 7aga
        {
            laserLine.SetPosition(0, this.GetComponent<Transform>().position);              // b5ly el starting point hya el this.GetComponent<Transform>()
            laserLine.SetPosition(1, this.GetComponent<Transform>().position + this.GetComponent<Transform>().right * laserMaxRange);          // b5ly el ending point hya el max range
            // Instantiate(onImpactEffect, this.GetComponent<Transform>().position + this.GetComponent<Transform>().right * laserMaxRange, Quaternion.identity);
        }
        laserLine.enabled = true;        // kda el laser visible
        // yield return new WaitForSeconds(1f);
        // nextFalseTime = Time.time + 1f;
        // while (Time.time < nextFalseTime)
        // {
        //     // hitObjectInfo.transform.name
        // }
        // StartCoroutine(la7za());         // Wait shwya
        // if(Time.time >= nextFalseTime)
        // {
            // Debug.Log("5lah true");
        // laserLine.enabled = false;       // kda el laser invisible
        //     nextFalseTime = Time.time + 1f;

        // }

    }

    float Distance(RaycastHit2D hitObjectInfo)
    {
        // This line might seem scary, but I promise, it simply calculates the distance between 2 points :D
        return Mathf.Sqrt((hitObjectInfo.transform.position.x - this.GetComponent<Transform>().position.x)*(hitObjectInfo.transform.position.x - this.GetComponent<Transform>().position.x) + (hitObjectInfo.transform.position.y - this.GetComponent<Transform>().position.y)*(hitObjectInfo.transform.position.y - this.GetComponent<Transform>().position.y));
        // Debug.Log($"bta3ty: {Mathf.Sqrt((hitObjectInfo.transform.position.x - this.GetComponent<Transform>().position.x)*(hitObjectInfo.transform.position.x - this.GetComponent<Transform>().position.x) + (hitObjectInfo.transform.position.y - this.GetComponent<Transform>().position.y)*(hitObjectInfo.transform.position.y - this.GetComponent<Transform>().position.y))}");
        // Debug.Log($"bta3thom: {Vector3.Distance(hitObjectInfo.transform.position, this.GetComponent<Transform>().position)}");
        // return Vector3.Distance(hitObjectInfo.transform.position, this.GetComponent<Transform>().position);
    }
    // IEnumerator la7za()
    // {
    //     yield return new WaitForSeconds(waitingTime);
    // }
}
