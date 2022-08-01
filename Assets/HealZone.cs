using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealZone : MonoBehaviour, IZone
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
        if (playerVars.health < playerVars.maxHealth)     // mtzawedsh 3n el max
        {
            playerVars.health += playerVars.health * 0.00015f;   // kol sanya by2alel 7aba, bs el value btzeed kol shwya
        }
        if (playerVars.health > playerVars.maxHealth)
        {
            playerVars.health = playerVars.maxHealth;
        }
    }
}
