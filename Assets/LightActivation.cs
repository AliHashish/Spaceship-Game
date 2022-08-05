using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightActivation : MonoBehaviour
{
    GameObject player = null;
    Light2D zoneLight;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        zoneLight = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player.transform.position, transform.position) <+ zoneLight.pointLightInnerRadius)
        {
            zoneLight.intensity= Mathf.PingPong(Time.time, 1.5f);
        }
    }
}
