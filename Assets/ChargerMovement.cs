using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargerMovement : MonoBehaviour
{
    private enum ChargerState 
    {
        Idle,
        Transition,
        Charge,
    }
    private ChargerState state;
    SpriteRenderer rend;
    Color C;
    public float chargingSpeed = 4f;                          // force by which enemy charges at player
    public float health = 150f;     // initially, health = 150
    public float maxHealth = 150f;     // initially, max health = 150
    public ParticleShootingLogic playerVars;         // To access some variables
    public float transitionTime = 1.5f;       // byo3od ad eih 3la ma yen2el mn state lel tanya
    float nextAttackTime = 0f;
    public float damage = 15f;

    public GameObject player;
    // public GameObject enemy;
    public float attackRange = 1.3f;        // y2dr ydrb mn 3la bo3d ad eih
    public float movingSpeed = 1f;         // el sor3a el hyemshy byha
    public Rigidbody2D rb;              // byshawer 3l rigidbody bta3 el enemy

    private Vector2 lookDir;
    private float angle;
    // Start is called before the first frame update
    void Start()
    {
        state = ChargerState.Idle;
        // Debug.Log($"State: {state}, int {(int)(state)}");
        rend = GetComponent<SpriteRenderer> ();
        C = rend.material.color;
        C.a = 0.5f;
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
        // C.a = 0.5f;
        // rend.material.color = C;
        switch (state)
        {
        case ChargerState.Idle:
            // hy-check lw el player da5al el radius bta3o
            // Debug.Log("Idle");
            if (Vector3.Distance(player.transform.position, transform.position) < attackRange)
            {
                state = ChargerState.Transition;
                nextAttackTime = Time.time + transitionTime;
            }
            break;
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        case ChargerState.Transition:
            // hybos lel player, w ystna shwya, w lono yo3od yt8yr, 3lshan el player y3rf eno hy-attacko, b3dein y5osh fl chargin state
            // Debug.Log("Transition");
            // bybos lel player
            lookDir = (Vector2) player.transform.position - rb.position;       // el far2 ma bein el enemy wl player howa el vector mn el player lel enemy
            angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90f;;                                   
            rb.rotation = angle;


            // Color changes gradually
            if (C.a > 0.5f)
            {
                // Debug.Log($"Before: C.a = {C.a}");
                C.a -= 0.01f;
                rend.material.color = C;
                // Debug.Log($"After: C.a = {C.a}");
            }
            

            // hyo3od lono yt8yr, l7d ma wa2t el transition (4 swany mthln) ye5las, sa3etha en2el lel Charge state
            if (Time.time >= nextAttackTime)
            {
            
                
                // StartCoroutine(WaitSomeTime(4));        // 8albn msh m7tagha 5las, momkn a3ml for loop bs // la wala 7ata for loop 5las
            

                state = ChargerState.Charge;
                nextAttackTime = Time.time + transitionTime;
            }
            break;

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        case ChargerState.Charge:
            // hy-charge ne7yet el player, w lw 5abato hyna2aso w yrg3 lel state le idle b3deeha, w lono yrg3 zy ma kan
            // Debug.Log("Charge");


            
            // color returns gradually
            if (C.a < 1f)
            {
                // Debug.Log($"Before: C.a = {C.a}");
                C.a += 0.01f;
                rend.material.color = C;
                // Debug.Log($"After: C.a = {C.a}");
            }
            
            lookDir = (Vector2) player.transform.position - rb.position;       // el far2 ma bein el enemy wl player howa el vector mn el player lel enemy
            angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90f;;                                   
            rb.rotation = angle;

            if (Time.time >= nextAttackTime)
            {
                // Debug.Log("Charging dlw2ty");
                // charge 3l player
                gameObject.GetComponent<Rigidbody2D>().AddForce(this.transform.up * -chargingSpeed, ForceMode2D.Impulse);
                
                nextAttackTime = Time.time + transitionTime;
                state = ChargerState.Idle;
            }
            break;
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        default:
            break;
        }
    }

    IEnumerator WaitSomeTime(float seconds)
    {
        // C.g = 55f/255f;
        // C.b = 55f/255f;
        // rend.material.color = C;
        // Debug.Log("a7mr");
        yield return new WaitForSeconds(seconds);
    }

    IEnumerator RegainColour(float seconds)
    {
        C.g = 1f;
        C.b = 1f;
        rend.material.color = C;
        // Debug.Log("asly");
        yield return new WaitForSeconds(seconds);
    }


    private void OnCollisionEnter2D(Collision2D bullet) 
    {
        // Debug.Log("particle darabetny");
        if (bullet.gameObject.CompareTag("FriendlyFire"))   // el player byedrabny b particles
        {
            // m7tag a-check hena lw el player masek laser msh particle gun
            health -= playerVars.damage;
        }
        else if (bullet.gameObject.CompareTag("Player") && !(bullet.transform.GetComponent<PlayerPickUp>().shield))    // ana 5abat fl player
        {
            bullet.transform.GetComponent<PlayerPickUp>().health -= damage;
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
