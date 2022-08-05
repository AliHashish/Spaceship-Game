using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public GameObject explosionEffect = null;
    public float hitPoints = 3f;
    public float explosionRadius = 0f;
    public float explosionDamage = 0f;
    [SerializeField] private LayerMask layerMask;
    private float totalHitPoints = 3f;
    SpriteRenderer rend;
    Color C;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer> ();
        C = rend.material.color;
        totalHitPoints = hitPoints;
    }

    // Update is called once per frame
    void Update()
    {
        if (hitPoints < totalHitPoints)
        {
            C.a = 0.5f;
            rend.material.color = C;
        }
        if (hitPoints <= 0)
        {
            Explode();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("FriendlyFire"))
        {
            Debug.Log("Noice");
            hitPoints--;
        }
    }

    void Explode()
    {
        if (explosionEffect)
        {
            GameObject effect = Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.41f);    // bn3ml destroy bs b3deeha b 0.41 seconds
        }
        Debug.Log("exploded");
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, explosionRadius, layerMask);
        foreach(Collider2D obj in objects)
        {
            // Debug.Log($"Object: {obj.transform.name}");
            if(obj.transform.GetComponent<PlayerPickUp>())
            {
                // Debug.Log("Player");
                obj.transform.GetComponent<PlayerPickUp>().health -= explosionDamage;
            }
            else if (obj.transform.GetComponent<EnemyInfo>())
            {
                obj.transform.GetComponent<EnemyInfo>().health -= explosionDamage;
            }
            else if (obj.transform.GetComponent<ChargerMovement>())
            {
                obj.transform.GetComponent<ChargerMovement>().health -= explosionDamage;
            }
        }
    }
}
