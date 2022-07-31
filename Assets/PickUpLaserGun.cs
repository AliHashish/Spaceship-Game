using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpLaserGun : MonoBehaviour, IPickUpItem
{
    public GunShoot gunVars;         // To access some variables
    public PlayerShoot playerVars;               // To access some variables
    public GameObject laserShot;                // Storing the laser shot prefab
    
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
        gunVars.shotType = laserShot;        // 8ayar el prefab
        if (playerVars.attackRate < 40)
        {
            playerVars.attackRate *= 50;        // lw kan particle, edrab el attack rate fy 50
            // laken lw howa asln laser, seebo zy ma howa
        }
    }
}
