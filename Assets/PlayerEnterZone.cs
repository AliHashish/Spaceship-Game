using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnterZone : MonoBehaviour
{
    // int i=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // e3ml function zy dyh fl enemy bs, kda el enemy can both heal and get damaged by zones
    private void OnTriggerStay2D(Collider2D enteredZone)
    {
        // i++;
        // Debug.Log($"da5al gowaya {i}");

        var zone = enteredZone.GetComponent<IZone>();
        if(zone != null)  // lw la2a item y2dr yt3mlha pickup
        {
            zone.ZoneEffect();
            
        }
    }
}
