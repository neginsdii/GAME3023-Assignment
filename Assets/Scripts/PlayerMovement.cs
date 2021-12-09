using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    public float speed;
    private Animator anim;
    private AudioSource footstepsSound;
    private float deltaX, deltaY;
    private ParticleSystem dustTrail;
    public Color grassColor,dustColor;
    private bool isMoving =false;
    void Start()
    {
        LoadPlayerLocation();
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        footstepsSound = GetComponent<AudioSource>();
        dustTrail = GetComponentInChildren<ParticleSystem>();
    }
    private void LoadPlayerLocation()
    {
        Vector3 loadedLocation = transform.position;
        if (PlayerPrefs.HasKey("PlayerPositionX"))
            loadedLocation.x = PlayerPrefs.GetFloat("PlayerPositionX");
        if (PlayerPrefs.HasKey("PlayerPositionY"))
            loadedLocation.y = PlayerPrefs.GetFloat("PlayerPositionY");
        if (PlayerPrefs.HasKey("PlayerPositionZ"))
            loadedLocation.z = PlayerPrefs.GetFloat("PlayerPositionZ");
        transform.position = loadedLocation;
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
        PlayFootStep();
        DustTrailGeneration();
    }

    private void DustTrailGeneration()
    {
        if (isMoving)
        {
            dustTrail.GetComponent<Renderer>().material.SetColor("_Color", dustColor);
            dustTrail.Play();
        }
        else
            dustTrail.Pause();
    }

    private void PlayFootStep()
    {
        if (deltaX != 0 || deltaY != 0)
        {
            isMoving = true;
            if (!footstepsSound.isPlaying)
                footstepsSound.Play();
        }
        else
        {
            isMoving = false;
            footstepsSound.Pause();
        }
    }
    private void animationUpdate()
    {
        if (body.velocity.x < 0)
        {
            anim.SetBool("left", true);
            anim.SetBool("right", false);
            anim.SetBool("up", false);
            anim.SetBool("down", false);
        }
        else if (body.velocity .x > 0)
        {
            anim.SetBool("right", true);
            anim.SetBool("left", false);
            anim.SetBool("up", false);
            anim.SetBool("down", false);
        }
        else if (body.velocity .y< 0)
        {
            anim.SetBool("left", false);
            anim.SetBool("right", false);
            anim.SetBool("up", false);
            anim.SetBool("down", true);
        }
        else if (body.velocity.y > 0)
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
