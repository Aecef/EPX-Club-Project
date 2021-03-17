using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{


    private Rigidbody2D rb;
    public float speed = 0.0f;
    private Vector2 moveVelocity;
    private Animator anim;
    private SpriteRenderer sr;
    private bool dashWait = false;


    // Use this for initialization
    void Start()
    {

        //Obtains info from the player sprite
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        //Keeps the sprite upright
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        //Decides the direction of the desired velocity
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
        

        //Allows the animator ro know if the sprite is moving
        if (moveVelocity.magnitude > 0.01f)
        {
            anim.SetBool("Moving", true);
        }
        else
        {
            anim.SetBool("Moving", false);
        }

        anim.SetFloat("Speed", moveVelocity.magnitude);
        print(moveVelocity.magnitude);

    }

    void FixedUpdate()
    {
        //Should flip the sprite to face the direction its moving
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            if (Input.GetAxisRaw("Horizontal") >= 0.01f)
            {
                sr.flipX = false;
            }
            else if (Input.GetAxisRaw("Horizontal") <= 0.01f)
            {
                sr.flipX = true;
            }
        }
        if (Input.GetKey(KeyCode.LeftShift) && !dashWait)
        {
            rb.MovePosition(rb.position + (moveVelocity * Time.fixedDeltaTime * 10));
            anim.SetBool("Dash", true);
            StartCoroutine(dashWaitChange());
            
        }
        else
        {
            rb.MovePosition(rb.position + (moveVelocity * Time.fixedDeltaTime));
        }

        IEnumerator dashWaitChange()
        {
            yield return new WaitForSeconds(3f);
            anim.SetBool("Dash", false);
            dashWait = true;
            yield return new WaitForSeconds(2);
            dashWait = false;


        }
    }
}
