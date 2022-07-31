using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleShootingLogic : MonoBehaviour, IGunType
{
    // public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 1.25f;         // sor3et el bullet
    // 1.25 for enemies, 2 for player
    
    public int NumBullets = 1;                // htedrab kam bullet fl mara
    // momkn a3mlha for loop ez gowa el Shoot(), kol mara y-spawn wa7da fy makan shifted 3n el ableeha b value mo3yna / 3adadhom
    // kda kol ma 3adadhom yzeed, el value dyh ht2el, l2n el denominator b2a akbar
    // kinda like, float value = 18/NumBullets mthln;
    // 5ly awl bullet fl nos kda w kda, b3dein spawn fo2eeha bl msafa, b3dein t7teeha bl msafa, b3dein fo2eeha, w hakaza
    // e.g, lw el msafa = satr

    // 4            (dlw2ty ba2et arb3 stoor le ta7t)
    // 2            (dlw2ty ba2et satrein le ta7t)
    // 1            (dlw2ty el msafa ba2et = satr le fo2)
    // 3            (dlw2ty ba2et tlat stoor le fo2)
    // 5            (w hakaza ba2a, el mra el gya hatla3 6 le fo2)

    // la7ez en kol mara, el msafa btzeed 3n el ableeha b satr wa7ed bs, fa el implementation sahl y3ny

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
