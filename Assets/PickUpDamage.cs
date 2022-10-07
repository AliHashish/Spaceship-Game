using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpDamage : MonoBehaviour, IPickUpItem
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
        laserVars.damage *= 1.1f;   // adds 10% of current damage
        particleVars.damage *= 1.1f;   // adds 10% of current damage
        VariableStorage.playerLaserDamage = laserVars.damage;
        VariableStorage.playerParticleDamage = particleVars.damage;
    }
}
