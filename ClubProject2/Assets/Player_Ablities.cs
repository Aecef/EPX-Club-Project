using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Ablities : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;
    public GameObject shield;
    public bool invincible = false;


    // Use this for initialization
    void Start()
    {

        //Obtains info from the player sprite
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            Instantiate(shield);
        }

    }
}
