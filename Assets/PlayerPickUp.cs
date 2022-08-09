using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    public bool key = false;        // Key to free the 2nd player
    public bool shield = false;     // initially, player has no shield
    public float health = 150f;     // initially, player health = 150
    public float maxHealth = 150f;     // initially, player max health = 150
    SpriteRenderer rend;

    public PlayerShoot playerVars;     // To access attackRate variable

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D pickedUpItem)
    {
        Debug.Log("5abat fya");
        var item = pickedUpItem.GetComponent<IPickUpItem>();
        if(item != null)  // lw la2a item y2dr yt3mlha pickup
        {
            item.PickUp();

        }
        
        // kan momkn n3ml hena wait wa2t mo3yn, b3dein item.ReversePickUpEffect();
        // dyh htb2a zy item.PickUp(); bs htb2a fadya fl 7agat el permanent, w htb2a bt-reverse
        // el effect fl 7agat el temporary


        // 8albn el coroutine hyet7at hena
        if (pickedUpItem.gameObject.CompareTag("TempShield"))
        {
            StartCoroutine(ShieldWaitTime(10f));       // waits for some time
        }
        else if (pickedUpItem.gameObject.CompareTag("TempAttackRate"))
        {
            StartCoroutine(AttackRateWaitTime(10f));       // waits for some time
        }

    }

    IEnumerator ShieldWaitTime(float waitTime)
    {
        // Debug.Log("Wait");
        yield return new WaitForSeconds(waitTime);
        rend.material.color = Color.white;      // returns colour to its original values
        shield = false;                         // disables shield
        // Debug.Log("Some Time");
    }

    IEnumerator AttackRateWaitTime(float waitTime)
    {
        // Debug.Log("Wait");
        yield return new WaitForSeconds(waitTime);
        playerVars.attackRate /= 2;
        // Debug.Log("Some Time");
    }
}
