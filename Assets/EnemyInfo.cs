using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    public float health = 150f;     // initially, health = 150
    public float maxHealth = 150f;     // initially, max health = 150
    public ParticleShootingLogic playerVars;         // To access some variables

    SpriteRenderer rend;
    Color C;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer> ();
        C = rend.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        C.b = C.g = health / maxHealth;     // lono bye2leb a7mar kol ma yetdereb aktr
        rend.material.color = C;
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

    private void OnTriggerStay2D(Collider2D enteredZone)
    {
        // i++;
        // Debug.Log($"da5al gowaya {i}");

        var zone = enteredZone.GetComponent<IZone>();
        if(zone != null)  // lw la2a item y2dr yt3mlha pickup
        {
            zone.ZoneEffect(false, gameObject);
            // false indicates that this is the enemy, not the player
            // in that case, we send the gameObject to know exactly which enemy it is
        }
    }
}
