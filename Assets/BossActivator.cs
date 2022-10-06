using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;           // 3lshan ast3ml el events

public class BossActivator : MonoBehaviour
{
    [Header("Custom Event")]            // 3lshan ast3ml el events
    public UnityEvent customEvent;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            customEvent?.Invoke();       // To invoke the event(s)
        }
    }
}
