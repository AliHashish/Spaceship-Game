using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParticleShot : MonoBehaviour
{
    // el particle shot dyh bta3t el enemy bs
    // el player lyh particle shot mo5tlfa


    public GameObject hitEffect;
    // public PlayerPickUp playerVars;         // To access some variables
    // public ParticleShootingLogic particleVars;  // To access some variables

    public int damage = 3;
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
        // Debug.Log("Garab kda");
        // bn-instantiate el hit effect, w bn3mlo store fy object, 3lshan n3mlo destroy b3deeha
        Destroy(effect, 0.41f);    // bn3ml destroy bs b3deeha b 0.41 seconds
        Destroy(gameObject);    // bn3ml destroy lel bullet
        
        // h5ly el object ya5od damage b2a
        if(other.gameObject.CompareTag("Player") && !other.gameObject.GetComponent<PlayerPickUp>().shield)       // lw 5abat el player, hna2as el health bta3o
        {
            // Debug.Log(other.gameObject.GetComponent<PlayerPickUp>().health);
            other.gameObject.GetComponent<PlayerPickUp>().health -= damage;
        }
        // }
    }
}
