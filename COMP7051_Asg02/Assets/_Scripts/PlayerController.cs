﻿using UnityEngine;
using System;

/**control player character movement and animation*/
public class PlayerController : MonoBehaviour {

    /**Character turning speed*/
    public float turnSpeed = 100;

    /**character walking speed*/
    public float walkSpeed = 5;

    /**character running speed*/
    public float runSpeed = 10;

    public GameObject Flashlight;   /**< The player's flashlight. */
    
    /**The projectile that the player can fire*/
    public Projectile projectilePrefab;

    /**The spawn point of the projectile when firing*/
    public Transform projectileSpawn;

    /**The speed at whicht he projectile is fired*/
    public float projectileSpeed = 40;

    /**player character's rigidbody*/
    private Rigidbody rb;

    /**is the player able to walk through walls*/
    private bool detectCollisions = true;

    /** the animaor that handles the player character's animations*/
    private Animator anim;

    private bool isRunning = false;

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
        if (anim == null)
            Debug.Log("no animator found on" + gameObject.name);

        rb = GetComponent<Rigidbody>();
    }
    /*
    void Update() {
        if (Input.touchCount == 1) {
            //forward movement
            Touch touchZero = Input.GetTouch(0);
            float moveSpeed = touchZero.position.y / Screen.height;
            transform.Translate(transform.forward * moveSpeed * walkSpeed * Time.deltaTime, Space.World);


            //rotation
            float rotateSpeed = touchZero.position.x / Screen.width - .5f;
            transform.Rotate(0, rotateSpeed * turnSpeed * Time.deltaTime, 0);
            anim.SetFloat("forwardMotion", 1);
        }
    }
    */
        // Update is called once per frame
        void Update() {
        if (Application.platform != RuntimePlatform.Android && IRefs.GetKeyDown(IRefs.Command.ThrowBall)) { 
            fire();
        }

            if (Input.GetAxis("Vertical") > .1) {
            anim.SetFloat("forwardMotion", Input.GetAxis("Vertical"));
        }
        else {
            anim.SetFloat("forwardMotion", 0);
        }

        //if run button is held down enable running
        if (Application.platform != RuntimePlatform.Android && IRefs.GetKey(IRefs.Command.PlayerRun))
            isRunning = true;
        else
            isRunning = false;

        anim.SetBool("run", isRunning);

        float speed = isRunning ? runSpeed : walkSpeed;

        //forward movement (controller and keyboard)
        if (Input.GetAxis("Vertical") > 0) {
            transform.Translate(transform.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime, Space.World);
        }

        //rotation (controller and keyboard)
        if (Input.GetAxis("Horizontal") != 0) {
            transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);
            anim.SetFloat("forwardMotion", 1);
        }

        //mouse controls for character movement and rotation
        if (Input.touchCount == 0 && Input.GetMouseButton(0)) {
            transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);

            float rotationDirection = Input.mousePosition.x / (Screen.width / 2) - 1;
            transform.Rotate(0, rotationDirection * turnSpeed * Time.deltaTime, 0);
            anim.SetFloat("forwardMotion", 1);
        }

        //touchscreen controls movement and rotation
        if (Input.touchCount == 1) {
            //forward movement
            Touch touchZero = Input.GetTouch(0);
            float moveSpeed = touchZero.position.y / Screen.height;
            transform.Translate(transform.forward * moveSpeed * speed * Time.deltaTime, Space.World);


            //rotation
            float rotateSpeed = touchZero.position.x / Screen.width - .5f;
            transform.Rotate(0, rotateSpeed * turnSpeed * Time.deltaTime, 0);
            anim.SetFloat("forwardMotion", 1);
        }

        if (IRefs.GetKeyDown(IRefs.Command.ToggleWalkThroughWalls))
            toggleDetectCollisions();

        /* Start and stop footsteps SFX. */
        if ((anim.GetFloat("forwardMotion") > 0) && 
            !(gameObject.GetComponent<AudioController>().FootstepsAudio.isPlaying))
        {
            gameObject.GetComponent<AudioController>().PlayAudio(AudioController.AudioNames.Footsteps);
        }
        else if ((anim.GetFloat("forwardMotion") == 0))
        {
            gameObject.GetComponent<AudioController>().StopAudio(AudioController.AudioNames.Footsteps);
        }

        /* Toggle the player's flashlight if input received. */
        ToggleFlashlight();
    }
    
    /**toggles ability to walk through walls*/
    public void toggleDetectCollisions() {
        detectCollisions = !detectCollisions;
        rb.isKinematic = !detectCollisions;
    }

    /**
        Toggle the player's flashlight if input received.
    */
    public void ToggleFlashlight(bool assumeInput = false)
    {
        if (assumeInput ||
            IRefs.GetKeyDown(IRefs.Command.ToggleFlashlight, 1, IRefs.InputSource.Any))
        {
            Flashlight.SetActive(!Flashlight.activeSelf);
        }
    }

    /**
        Plays a sound effect when the player collides with a wall.

        @param collision - The Collision object describing the collision event.
    */
    void OnCollisionEnter(Collision collision)
    {
        /* If the object collided with was a wall, play the wall collision sound effect. */
        if (collision.collider.CompareTag("Wall"))
        {
            gameObject.GetComponent<AudioController>().PlayAudio(AudioController.AudioNames.WallCollision);
        }
    }

    public void fire() {
        // Create the Bullet from the Bullet Prefab
        Projectile ball = (Projectile)Instantiate(
            projectilePrefab,
            projectileSpawn.position,
            projectileSpawn.rotation);

        // Add velocity to the bullet
        ball.GetComponent<Rigidbody>().velocity = ball.transform.forward * projectileSpeed;
    }
}
