using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowPickUp : MonoBehaviour, IPickUpItem
{
    public PlayerMovement playerVars;
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
        playerVars.moveSpeed = 1.5f;
    }
}
