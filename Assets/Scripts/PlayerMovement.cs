using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    public float speed;
    private Animator anim;

    private float deltaX, deltaY;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        deltaX = Input.GetAxisRaw("Horizontal");
        deltaY = Input.GetAxisRaw("Vertical");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        body.velocity = new Vector2(deltaX * speed, deltaY * speed);
        animationUpdate();
    }
    private void animationUpdate()
    {
        if (deltaX < 0)
        {
            anim.SetBool("left", true);
            anim.SetBool("right", false);
            anim.SetBool("up", false);
            anim.SetBool("down", false);
        }
        else if (deltaX > 0)
        {
            anim.SetBool("right", true);
            anim.SetBool("left", false);
            anim.SetBool("up", false);
            anim.SetBool("down", false);
        }
        else if (deltaY < 0)
        {
            anim.SetBool("left", false);
            anim.SetBool("right", false);
            anim.SetBool("up", false);
            anim.SetBool("down", true);
        }
        else if (deltaY > 0)
        {
            anim.SetBool("left", false);
            anim.SetBool("right", false);
            anim.SetBool("up", true);
            anim.SetBool("down", false);
        }
        else
        {
            anim.SetBool("left", false);
            anim.SetBool("right", false);
            anim.SetBool("up", false);
            anim.SetBool("down", false);
        }


    }
}
