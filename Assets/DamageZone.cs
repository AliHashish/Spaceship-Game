using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour, IZone
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

    public void ZoneEffect()
    {
        // h7tag azwd hena check 3l enemy lw kda, 3lshan howa kaman yetdereb
        if (!playerVars.shield && playerVars.health > playerVars.maxHealth * 0.5)     // mt2alelsh lw a2al mn noso already
        {
            playerVars.health -= playerVars.health * 0.00015f;   // kol sanya by2alel 7aba, bs el value bt2el kol shwya
        }
    }
}
