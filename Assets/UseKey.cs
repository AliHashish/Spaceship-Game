using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseKey : MonoBehaviour
{
    public GameObject Gates;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            // Debug.Log("El player da5al");
            if(other.gameObject.GetComponent<PlayerPickUp>().key)   // if player has the key
            {
                // Debug.Log("w m3ah key");
                if(Input.GetKeyDown(KeyCode.E))
                {
                    // Debug.Log("w das E");
                    if (Gates)
                    {
                        // Debug.Log("w fy gates kaman");
                        Destroy(Gates);
                    }
                }
            }
        }
    }
}
