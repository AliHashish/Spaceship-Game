using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBulletNumLaserWidth : MonoBehaviour, IPickUpItem
{
    public ParticleShootingLogic particleVars;         // To access some variables
    public LaserShootingLogic laserVars;               // To access some variables
    
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
        laserVars.laserWidth *= 1.1f;   // adds 10% of current damage
        particleVars.numBullets++;      // adds 1 bullet
        if (particleVars.numBullets > 7)
        {
            particleVars.numBullets = 7;        // so it doesn't exceed the maximum
        }
        if (laserVars.laserWidth > 0.2f)
        {
            laserVars.laserWidth = 0.2f;
        }
    }
}
