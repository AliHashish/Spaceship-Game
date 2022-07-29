using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;        // Default value a2dr a8yrha mn bara 3ady (mn unity)

    public Rigidbody2D rb;              // byshawer 3l rigidbody bta3 el player, l2n dh el hyt7rk m3 el player
    public Camera cam;                  // object mn el camera, 3lshan n3rf el mouse fein

    Vector2 movement;                   // h5azen fyh lama yt7rk
    Vector2 mousePos;                   // h5azen fyh mkan el mouse


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");    // ymeen shmal
        movement.y = Input.GetAxisRaw("Vertical");      // fo2 ta7t

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);     // kda m3ana makan el mouse
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);  // yt7rk b constant speed

        Vector2 lookDir = mousePos - rb.position;       // el far2 ma bein el mouse wl player howa el vector mn el player lel mouse
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;                                   
        // btgeeb el angle el m7tagenha bs bl radians, fa bn7wlha le degrees

        rb.rotation = angle;    // b7otaha lel player b2a
    }
}
