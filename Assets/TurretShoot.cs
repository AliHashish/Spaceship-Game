using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;           // 3lshan ast3ml el events

public class TurretShoot : MonoBehaviour
{
    [Header("Custom Event")]            // 3lshan ast3ml el events
    public UnityEvent customEvent;

    public float attackRate = 1.5f;       // y2dr y3ml kam attack fl sanya
    float nextAttackTime = 0f;
    int angle = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            // void Shoot();
            customEvent.Invoke();       // To invoke the event(s)
            // Shoot();
            nextAttackTime = Time.time + 1f / attackRate;
            transform.eulerAngles = Vector3.forward * angle;
            angle += 30;
            angle %= 90;
        
        }
    }
}
