using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleShot : MonoBehaviour
{
    // el particle shot dyh bta3t el player bs
    // el enemy h3mlo particle shot mo5tlfa


    public GameObject hitEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D other) 
    {
        // 3ayez at2kd eny m5abatesh el player tho
        // if (!(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("FriendlyFire")))  // msh m7tagha 5las 3lshan 8yrt el setting bta3t el layers
        // {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        // bn-instantiate el hit effect, w bn3mlo store fy object, 3lshan n3mlo destroy b3deeha
        Destroy(effect, 0.41f);    // bn3ml destroy bs b3deeha b 0.41 seconds
        Destroy(gameObject);    // bn3ml destroy lel bullet
        // h5ly el object ya5od damage b2a
        // }
    }
}
