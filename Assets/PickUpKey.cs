using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : MonoBehaviour, IPickUpItem
{
    public PlayerPickUp playerVars;

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
        playerVars.key = true;
    }
}
