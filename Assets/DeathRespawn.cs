using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathRespawn : MonoBehaviour
{
    public PlayerPickUp playerVars;         // To access some variables
    public Vector3 respawnPoint;
    // -1,  4
    // -6,  0
    //  0, -5
    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(transform.position);
        if (playerVars.health <= 0)
        {
            playerVars.health = playerVars.maxHealth;
            transform.position = respawnPoint;
            // Debug.Log($"spawn point {respawnPoint}");
            // Debug.Log($"player point {transform.position}");
        }
    }
}
