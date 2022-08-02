using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;           // 3lshan ast3ml el events

public class DroneShoot : MonoBehaviour
{
    [Header("Custom Event")]            // 3lshan ast3ml el events
    public UnityEvent customEvent;

    [SerializeField] private LayerMask layerMask;

    public float attackRate = 1.25f;       // y2dr y3ml kam attack fl sanya
    float nextAttackTime = 0f;

    public float movingRadius = 1f;        // masmo7lo yemshy one block at a time
    public float movingSpeed = 1f;         // el sor3a el hyemshy byha

    private Vector2 positionBeforeMoving;
    private Vector2 movingTo;
    
    // Start is called before the first frame update
    void Start()
    {
        positionBeforeMoving = gameObject.transform.position;
        movingTo = new Vector2(0,0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if (Time.time >= nextAttackTime)
        // {
        //     customEvent.Invoke();       // To invoke the event(s), dh el hy5leeh y-attack
            // nextAttackTime = Time.time + 1f / attackRate;
        //     // transform.eulerAngles = Vector3.forward * angle;
            MoveRandomly();
        // }
    }

    Vector2 GenerateRandomPoint()
    {
        // 8albn msh m7tag el currentPoint fy 7aga
        float length = UnityEngine.Random.Range(0f, movingRadius);
        float angle = UnityEngine.Random.Range(0f, 360f);
        Vector2 newPoint = new Vector2();
        newPoint.x = length * Mathf.Cos(angle * Mathf.Deg2Rad);
        newPoint.y = length * Mathf.Sin(angle * Mathf.Deg2Rad);
        // return newPoint + currentPoint;
        return newPoint;
    }

    void MoveRandomly()
    {
        // if (movingTo = gameObject.transform.position)    // y3ny wesel lel destination 5las
        if (positionBeforeMoving + movingTo == (Vector2)gameObject.transform.position)    // y3ny wesel lel destination 5las
        {
            // yb2a ha7seb destination mo5tlf w abtedy aro7lo
            positionBeforeMoving = gameObject.transform.position;   // b-save el makan el gdeed abl el 7araka
            movingTo = GenerateRandomPoint();
        }

        RaycastHit2D hitObjectInfo = Physics2D.Raycast(gameObject.transform.position, movingTo, movingRadius, layerMask);
        // 3mltaha movingRadius * 2 3lshan yeb2a sayeb msa7a fadya kaman zyada e7tyaty
        // Debug.DrawRay(transform.position, movingTo, Color.green, 0.1f);
        if (hitObjectInfo)          // 5abat 7aga
        {
            // yb2a mte2darsh temshy fl taree2 dh, e7sb taree2 mo5tlf
            positionBeforeMoving = gameObject.transform.position;   // b-save el makan el gdeed abl el 7araka
            movingTo = GenerateRandomPoint();
            Debug.Log($"5abat fy {hitObjectInfo.transform.name}, h8yr el destination to {(Vector2) gameObject.transform.position + movingTo}");
        }
        else
        {
            // ebtedy emsheelo madam eshta
            Debug.Log("El mrady h3rf a3ady eshta");
            transform.position = Vector2.MoveTowards(transform.position, (Vector2) transform.position + movingTo, movingSpeed * Time.fixedDeltaTime);
        }


    }
}