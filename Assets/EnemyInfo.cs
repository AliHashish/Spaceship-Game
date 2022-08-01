using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    public float health = 150f;     // initially, health = 150
    public float maxHealth = 150f;     // initially, max health = 150
    public ParticleShootingLogic playerVars;         // To access some variables

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D bullet) 
    {
        Debug.Log("particle darabetny");
        if (bullet.gameObject.CompareTag("FriendlyFire"))
        {
            health -= playerVars.damage;
        }

    }
}
