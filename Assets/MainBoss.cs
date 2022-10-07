using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;           // 3lshan ast3ml el events
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainBoss : MonoBehaviour
{
    [Header("Custom Event")]            // 3lshan ast3ml el events
    public UnityEvent customEvent;

    public float health = 5000f;     // initially, health = 5000
    public float maxHealth = 5000f;     // initially, max health = 5000
    public Slider slider;

    public float attackRate = 2f;       // y2dr y3ml kam attack fl sanya
    float nextAttackTime = 0f;
    public bool shoot = false;
    public float inversionRate = 0.25f;       // y2dr y3ml kam attack fl sanya
    float nextShootInversion = 0f;

    public ParticleShootingLogic playerVars;         // To access some variables
    public GameObject player;

    public float movingSpeed = 1f;         // el sor3a el hyemshy byha
    public Rigidbody2D rb;              // byshawer 3l rigidbody bta3 el enemy
    private Vector2 originalPosition;

    private enum BossState
    {
        Shooting,
        NotShooting,
    }
    private BossState state;



    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = health / maxHealth;
        if (health <= 0)
        {
            // w en2elo 3l dor elly b3do
            SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings);       // gets the next level
            // StartCoroutine(TimeDelay());
            Destroy(gameObject);
        }
        else if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    void FixedUpdate()
    {
        MoveHorizontally();
        AimAtPlayer();
        if (Time.time >= nextAttackTime)
        {
            if (shoot)
            {
                customEvent.Invoke();       // To invoke the event(s), dh el hy5leeh y-attack
            }
            nextAttackTime = Time.time + 1f / attackRate;
            if (Time.time >= nextShootInversion)
            {
                nextShootInversion = Time.time + 1f / inversionRate;
                shoot = !shoot;
            }
            // transform.eulerAngles = Vector3.forward * angle;
        }
    }

    void MoveHorizontally()
    {
        Vector2 movingTo = new Vector2(player.transform.position.x, originalPosition.y);
        transform.position = Vector2.MoveTowards(transform.position, movingTo, movingSpeed * Time.fixedDeltaTime);
    }

    void AimAtPlayer()
    {
        Vector2 lookDir = (Vector2)player.transform.position - rb.position;       // el far2 ma bein el enemy wl player howa el vector mn el player lel enemy
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90f; ;
        rb.rotation = angle;
    }

    private void OnCollisionEnter2D(Collision2D bullet)
    {
        // Debug.Log("particle darabetny");
        if (bullet.gameObject.CompareTag("FriendlyFire"))
        {
            health -= playerVars.damage;
        }

    }

    // IEnumerator TimeDelay()
    // {
    //     yield return new WaitForSeconds(0.85f);      // waits for 1.5 seconds abl ma yen2el el level
    //                                                  // dh 3lshan 5ater nel7a2 nesma3 el o8nya
    //     SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings);       // gets the next level
    //     // bs msh htb2a %3 b2a, h8ayar el rakam 3la asas 3adad el levels
    // }
}
