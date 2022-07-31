using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpShield : MonoBehaviour, IPickUpItem
{
    public PlayerPickUp playerVars;
    public GameObject player;

    SpriteRenderer rend;
    Color C;
    // Color noShieldColour;

    // Start is called before the first frame update
    void Start()
    {
        rend = player.GetComponent<SpriteRenderer> ();
        C = rend.material.color;
        // noShieldColour = C;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickUp()
    {
        Destroy(gameObject);
        playerVars.shield = true;
        C.r = 0f;
        C.g = 0f;
        C.b = 1f;
        rend.material.color = C;
        // 8albn lazem atl3ha bara
        // StartCoroutine(WaitSomeTime());
        // rend.material.color = noShieldColour;
        // playerVars.shield = false;
    }

    IEnumerator WaitSomeTime()
    {
        yield return new WaitForSeconds(5f);      // waits for a while before continuing
    }
}
