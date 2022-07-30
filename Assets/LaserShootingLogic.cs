using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShootingLogic : MonoBehaviour, IGunType
{
    public Transform firePoint;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        RaycastHit2D hitObjectInfo = Physics2D.Raycast(firePoint.position, firePoint.right);
        if (hitObjectInfo)
        {
            Debug.Log(hitObjectInfo.transform.name);
            // h7sb b2a el distance ma bein el firePoint.position wl object elly et5abat
            // w lw hya as8r mn el max distance bta3t el laser, h5leeh ya5od damage wl kalam dh
            // lw la, msh hya5od damage. wl effect bta3t el laser hye5talef
        }
    }
}
