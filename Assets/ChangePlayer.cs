using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChangePlayer : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    bool change = false;
    // Start is called before the first frame update
    void Start()
    {
        // var vcam = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        // cubes[i].SetActive(true);
        if(Input.GetKeyDown(KeyCode.T))
        {
            if(change)      // Switches to player 1
            {
                gameObject.GetComponent<CinemachineVirtualCamera>().Follow = player1.transform; // Makes camera follow player 1
                
                gameObject.transform.GetChild(2).gameObject.SetActive(false);   // Turns off 2nd player healthbar
                player2.GetComponent<BoxCollider2D>().enabled = false;          // Turns off 2nd player box collider
                player2.GetComponent<PlayerMovement>().enabled = false;         // Turns off 2nd player movement
                player2.GetComponent<PlayerShoot>().enabled = false;            // Turns off 2nd player shooting

                gameObject.transform.GetChild(1).gameObject.SetActive(true);    // Turns on 1st player healthbar
                player1.GetComponent<BoxCollider2D>().enabled = true;           // Turns on 1st player box collider
                player1.GetComponent<PlayerMovement>().enabled = true;          // Turns on 1st player movement
                player1.GetComponent<PlayerShoot>().enabled = true;             // Turns on 1st player shooting
                
                change = false;
            }
            else            // Switches to player 2
            {
                gameObject.GetComponent<CinemachineVirtualCamera>().Follow = player2.transform;
                
                gameObject.transform.GetChild(1).gameObject.SetActive(false);    // Turns off 1st player healthbar
                player1.GetComponent<BoxCollider2D>().enabled = false;           // Turns off 1st player box collider
                player1.GetComponent<PlayerMovement>().enabled = false;          // Turns off 1st player movement
                player1.GetComponent<PlayerShoot>().enabled = false;             // Turns off 1st player shooting

                gameObject.transform.GetChild(2).gameObject.SetActive(true);   // Turns on 2nd player healthbar
                player2.GetComponent<BoxCollider2D>().enabled = true;          // Turns on 2nd player box collider
                player2.GetComponent<PlayerMovement>().enabled = true;         // Turns on 2nd player movement
                player2.GetComponent<PlayerShoot>().enabled = true;            // Turns on 2nd player shooting
                change = true;
            }
        }
    }
}
