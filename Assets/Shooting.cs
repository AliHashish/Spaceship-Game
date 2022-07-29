using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 2f;         // sor3et el bullet

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    // the function that handles the shooting logic
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        // bn3ml object mn el bulletPrefab el 7atenaha, fl position dh, bl rotation dyh
        // w bn5azeno fy variable
        
        // bs e7na 3ayzeen n-access el rigidbody bta3 el bullet, fa hnst3ml getcomponent
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();    // bn5azen el rigidbody
        // hndeelo force b2a
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        // ba7aded el direction w no3 el force
    }
}
