using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealZone : MonoBehaviour, IZone
{
    public PlayerPickUp playerVars;         // To access some variables
    // public EnemyInfo enemyVars;         // To access some variables

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ZoneEffect(bool player, GameObject enemy = null)
    {
        // h7tag azwd hena check 3l enemy lw kda
        if (player)
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
        else
        {
            // el enemy
            EnemyInfo enemyVars = enemy.GetComponent<EnemyInfo>();
            if (enemyVars.health < enemyVars.maxHealth)     // mtzawedsh 3n el max
            {
                enemyVars.health += enemyVars.health * 0.00015f;   // kol sanya by2alel 7aba, bs el value btzeed kol shwya
            }
            if (enemyVars.health > enemyVars.maxHealth)
            {
                enemyVars.health = enemyVars.maxHealth;
            }
            
        }
    }
}
