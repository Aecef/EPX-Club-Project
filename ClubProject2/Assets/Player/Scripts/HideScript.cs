using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideScript : MonoBehaviour
{
    private Animator anim;
    public bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    //Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("left shift"))
        {
            anim.SetBool("Hiding", true);
            canMove = false;
            print("Hiding");
        }
        if (Input.GetKeyUp("left shift"))
        {
            anim.SetBool("Hiding", false);
            canMove = true;
            print("Done Hiding");
        }
    }
}


