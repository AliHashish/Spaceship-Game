using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBulletSpeedLaserMaxRange : MonoBehaviour, IPickUpItem
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
        laserVars.laserMaxRange *= 1.1f;   // adds 10% of current range
        particleVars.bulletForce *= 1.1f;   // adds 10% of current force
        VariableStorage.playerLaserMaxRange = laserVars.laserMaxRange;
        VariableStorage.playerParticleBulletForce = particleVars.bulletForce;
    }

}
