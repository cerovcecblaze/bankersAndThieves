using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class move : Photon.Pun.MonoBehaviourPun
{
    public float speed = 10;
    Vector2 velocity;
    Rigidbody2D rb;
    public Component characterBody;
    Animator anim;
    Joystick joystick;
    bool clicked = false;
    bool unClicked = false;
    float xCheck = 0F;
    float yCheck = 0F;

    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
        velocity = Vector2.zero;
    }

    private void Update() {
        if (photonView.IsMine)
        {

            //Debug.Log(velocity);
            //Debug.Log(xCheck);
            //Debug.Log(clicked);
            if (clicked)
            {
                if (unClicked)
                {
                    velocity.x = joystick.Horizontal;
                    velocity.y = joystick.Vertical;


                    if (Math.Abs(velocity.x) == 1 && Math.Abs(velocity.y) == 1)
                    {
                        velocity.x = velocity.x / (float)(1.414213562);
                        velocity.y = velocity.y / (float)(1.414213562);
                    }
                    if (velocity != Vector2.zero)
                    {



                        anim.SetBool("isWalking", true);
                        //rb.MovePosition(rb.position + velocity * speed * Time.fixedDeltaTime);

                    }
                    else
                    {
                        anim.SetBool("isWalking", false);
                    }

                }
                else
                {
                    xCheck = joystick.Horizontal;
                    yCheck = joystick.Vertical;

                    if (xCheck == 0)
                    {
                        unClicked = true;
                    }
                }

            }
            else
            {
                xCheck = joystick.Horizontal;
                yCheck = joystick.Vertical;
                if (xCheck != 0 && yCheck != 0)
                {
                    clicked = true;
                }
            }
            }

        }

    private void FixedUpdate()
    {
       
          rb.MovePosition(rb.position + velocity * speed * Time.fixedDeltaTime);
        
    }




    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        foreach (Transform child in transform)
        {
            if (child.name == "PlayerBody")
            {
                anim = child.gameObject.GetComponent<Animator>();
                Debug.Log("found");
            }
        }

    }
}
