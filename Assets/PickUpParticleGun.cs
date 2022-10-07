using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpParticleGun : MonoBehaviour, IPickUpItem
{
    public GunShoot gunVars;         // To access some variables
    public PlayerShoot playerVars;               // To access some variables
    public GameObject particleShot;             // Storing the particle shot prefab

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PickUp()
    {
        Destroy(gameObject);
        if (gunVars.shotType.GetComponent<LineRenderer>() != null)
        {
            gunVars.shotType.GetComponent<LineRenderer>().enabled = false;       // kda el laser invisible
        }
        gunVars.shotType = particleShot;        // 8ayar el prefab
        if (playerVars.attackRate > 40)
        {
            playerVars.attackRate /= 50;        // lw kan laser, e2sem el attack rate 3la 50
            // laken lw howa asln particle, seebo zy ma howa
        }
    }
}
