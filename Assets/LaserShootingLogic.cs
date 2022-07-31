using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShootingLogic : MonoBehaviour, IGunType
{
    // public Transform firePoint;
    public LineRenderer laserLine;
    // float waitingTime = 0f;

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
        // waitingTime = 1f;
        RaycastHit2D hitObjectInfo = Physics2D.Raycast(this.GetComponent<Transform>().position, this.GetComponent<Transform>().right);
        // 8albn m3naha lw el laser kamel fl etgah bta3o, hye5bat fy eih aw kda
        if (hitObjectInfo)
        {
            // Debug.Log(hitObjectInfo.transform.name);
            // Debug.Log(hitObjectInfo.transform.position);
            // Debug.Log(this.GetComponent<Transform>().position);
            // Debug.Log(firePoint.position);
            // h7sb b2a el distance ma bein el firePoint.position wl object elly et5abat
            // w lw hya as8r mn el max distance bta3t el laser, h5leeh ya5od damage wl kalam dh
            // lw la, msh hya5od damage. wl effect bta3t el laser hye5talef
            laserLine.SetPosition(0, this.GetComponent<Transform>().position);              // b5ly el starting point hya el this.GetComponent<Transform>()
            laserLine.SetPosition(1, hitObjectInfo.point);          // b5ly el ending point hya el 7aga elly et5abatet
            
            
            // Vector3 zeroVec = new Vector3(0f,0f,0f);
            // laserLine.SetPosition(0, zeroVec);              // b5ly el starting point hya el this.GetComponent<Transform>()
            // Vector2 posVec = new Vector2(0f,0f);
            // zeroVec = this.GetComponent<Transform>().position;
            // posVec.x = zeroVec.x;
            // posVec.y = zeroVec.y;
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


    // IEnumerator la7za()
    // {
    //     yield return new WaitForSeconds(waitingTime);
    // }
}
