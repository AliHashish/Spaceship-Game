using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleShot : MonoBehaviour
{
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
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        // bn-instantiate el hit effect, w bn3mlo store fy object, 3lshan n3mlo destroy b3deeha
        Destroy(effect, 0.41f);    // bn3ml destroy bs b3deeha b 5 seconds
        Destroy(gameObject);    // bn3ml destroy lel bullet
        
    }
}
