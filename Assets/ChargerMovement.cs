using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargerMovement : MonoBehaviour
{
    private enum ChargerState 
    {
        Idle,
        Transition,
        Charge,
    }
    private ChargerState state;
    SpriteRenderer rend;
    Color C;
    public float transitionTime = 4f;       // byo3od ad eih 3la ma yen2el mn state lel tanya
    float nextAttackTime = 0f;

    public GameObject player;
    public GameObject enemy;
    public float attackRange = 1.3f;        // y2dr ydrb mn 3la bo3d ad eih
    public float movingSpeed = 1f;         // el sor3a el hyemshy byha
    public Rigidbody2D rb;              // byshawer 3l rigidbody bta3 el enemy
    // Start is called before the first frame update
    void Start()
    {
        state = ChargerState.Idle;
        rend = player.GetComponent<SpriteRenderer> ();
        // lw 3mltaha player, bysht8l, laken enemy la for some reason
        C = rend.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        C.g = 0f;
        C.r = 0f;
        C.b = 0f;
        rend.material.color = C;
        // switch (state)
        // {
        // case ChargerState.Idle:
        //     // hy-check lw el player da5al el radius bta3o
        //     Debug.Log("Idle");
        //     if (Vector3.Distance(player.transform.position, transform.position) < attackRange)
        //     {
        //         state = ChargerState.Transition;
        //         nextAttackTime = Time.time + transitionTime;
        //     }
        //     break;
        // case ChargerState.Transition:
        //     // hybos lel player, w ystna shwya, w lono yo3od yt8yr, 3lshan el player y3rf eno hy-attacko, b3dein y5osh fl chargin state
        //     Debug.Log("Transition");
        //     // bybos lel player
        //     Vector2 lookDir = (Vector2) player.transform.position - rb.position;       // el far2 ma bein el enemy wl player howa el vector mn el player lel enemy
        //     float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90f;;                                   
        //     rb.rotation = angle;


        //     // Color changes gradually
        //     if (C.b > 55f / 255f)
        //     {
        //         Debug.Log($"Before: C.g = {C.g}, C.b = {C.b} ");
        //         C.g -= 1f / 255f;
        //         C.b -= 1f / 255f;
        //         rend.material.color = C;
        //         Debug.Log($"After: C.g = {C.g}, C.b = {C.b} ");
        //     }

        //     // hyo3od lono yt8yr, l7d ma wa2t el transition (4 swany mthln) ye5las, sa3etha en2el lel Charge state
        //     if (Time.time >= nextAttackTime)
        //     {
            
                
        //         // StartCoroutine(WaitSomeTime(4));        // 8albn msh m7tagha 5las, momkn a3ml for loop bs // la wala 7ata for loop 5las
            

        //         state = ChargerState.Charge;
        //         nextAttackTime = Time.time + transitionTime;
        //     }
        //     break;
        // case ChargerState.Charge:
        //     // hy-charge ne7yet el player, w lw 5abato hyna2aso w yrg3 lel state le idle b3deeha, w lono yrg3 zy ma kan
        //     Debug.Log("Charge");
        //     // color returns gradually
        //     if (C.b < 1f)
        //     {
        //         Debug.Log($"Before: C.g = {C.g}, C.b = {C.b} ");
        //         C.g += 1f / 255f;
        //         C.b += 1f / 255f;
        //         rend.material.color = C;
        //         Debug.Log($"After: C.g = {C.g}, C.b = {C.b} ");
        //     }

        //     if (Time.time >= nextAttackTime)
        //     {
        //         // Call Coroutine that changes colour gradually, and waits a while
        //         // StartCoroutine(RegainColour(2));
                
        //         nextAttackTime = Time.time + transitionTime;
        //         state = ChargerState.Idle;
        //     }
        //     break;
        // default:
        //     break;
        // }
    }

    // IEnumerator WaitSomeTime(float seconds)
    // {
    //     // C.g = 55f/255f;
    //     // C.b = 55f/255f;
    //     // rend.material.color = C;
    //     // Debug.Log("a7mr");
    //     yield return new WaitForSeconds(seconds);
    // }

    // IEnumerator RegainColour(float seconds)
    // {
    //     C.g = 1f;
    //     C.b = 1f;
    //     rend.material.color = C;
    //     Debug.Log("asly");
    //     yield return new WaitForSeconds(seconds);
    // }
}
