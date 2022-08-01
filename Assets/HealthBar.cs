using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public PlayerPickUp playerVars;         // To access some variables
    private Transform bar;

    // Start is called before the first frame update
    void Start()
    {
        bar = transform.Find("Bar");
        // bar.localScale = new Vector3(.4f,1f);
    }

    // Update is called once per frame
    void Update()
    {
        bar.localScale = new Vector3(playerVars.health / playerVars.maxHealth,1f);
    }
}
