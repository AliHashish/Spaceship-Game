using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHeal : MonoBehaviour, IPickUpItem
{
    public PlayerPickUp playerVars;         // To access some variables
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
        playerVars.health += playerVars.maxHealth * 0.1f;   // adds 10% of max health
        if (playerVars.health > playerVars.maxHealth)
        {
            playerVars.health = playerVars.maxHealth;       // makes sure health is valid
        }
    }
}
