using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleShootingLogic : MonoBehaviour, IGunType
{
    // public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 1.25f;         // sor3et el bullet
    // 1.25 for enemies, 2 for player

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        // Debug.Log(this.GetComponent<Transform>().position);
        // Debug.Log(firePoint.position);
        GameObject bullet = Instantiate(bulletPrefab, this.GetComponent<Transform>().position, this.GetComponent<Transform>().rotation);
        // bn3ml object mn el bulletPrefab el 7atenaha, fl position dh, bl rotation dyh
        // w bn5azeno fy variable
        
        // bs e7na 3ayzeen n-access el rigidbody bta3 el bullet, fa hnst3ml getcomponent
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();    // bn5azen el rigidbody
        // hndeelo force b2a
        rb.AddForce(this.GetComponent<Transform>().right * bulletForce, ForceMode2D.Impulse);
        // ba7aded el direction w no3 el force
    }
}
