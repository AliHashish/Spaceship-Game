using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    public GameObject shotType;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GeneralShoot()
    {
        // a-call el IGunType.Shoot();
        var obj = shotType.GetComponent<IGunType>();
        if (obj != null)
        {
            obj.Shoot();
        }
    }
}
