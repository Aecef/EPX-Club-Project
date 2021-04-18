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
    private HideScript hideScript;

    private NPC_Controller npc;


    // Use this for initialization
    void Start()
    {

        //Obtains info from the player sprite
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        hideScript = GetComponent<HideScript>();
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
        //Flip the sprite to face the direction its moving
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

        if (!inDialogue())
        {
            rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        }
    }
    
    // FOR TRIGGERING DIALOGUE
    // bool for preventing player movement during dialogue
    private bool inDialogue()
    {
        if (npc != null)
            return npc.DialogueActive();
        else
            return false;
    }
    // checks for Collider2D attached to gameObject with 'NPC' tag
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "NPC")
        {
            npc = collision.gameObject.GetComponent<NPC_Controller>();

            // 'E' to activate dialogue
            if(Input.GetKey(KeyCode.E))
                collision.gameObject.GetComponent<NPC_Controller>().ActivateDialogue();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        npc = null;
    }
}