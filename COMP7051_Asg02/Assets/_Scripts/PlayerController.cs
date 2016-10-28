using UnityEngine;
using System;

/**control player character movement and animation*/
public class PlayerController : MonoBehaviour {

    /**Character turning speed*/
    public float turnSpeed = 100;

    /**character walking speed*/
    public float walkSpeed = 5;

    /**character running speed*/
    public float runSpeed = 10;

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

    // Update is called once per frame
    void Update() {
        if (Input.GetAxis("Vertical") > .1)
            anim.SetFloat("forwardMotion", Input.GetAxis("Vertical"));
        else
            anim.SetFloat("forwardMotion", 0);

        //if run button is held down enable running
        if (IRefs.GetKey(IRefs.Command.PlayerRun))
            isRunning = true;
        else
            isRunning = false;

        anim.SetBool("run", isRunning);
        float speed = isRunning ? runSpeed : walkSpeed;

        //forward movement (controller and keyboard)
        if (Input.GetAxis("Vertical") > 0)
            transform.Translate(transform.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime, Space.World);
        
        //rotation (controller and keyboard)
        if (Input.GetAxis("Horizontal") != 0) {
            transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);
            anim.SetFloat("forwardMotion", 1);
        }

        //mouse controls for character movement and rotation
        if (Input.GetAxis("MoveForward") > 0) {
            transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);

            float rotationDirection = Input.mousePosition.x / (Screen.width / 2) - 1;
            transform.Rotate(0, rotationDirection * turnSpeed * Time.deltaTime, 0);
            anim.SetFloat("forwardMotion", 1);
        }

        //touchscreen controls movement and rotation
        if (Input.touchCount == 1) {
            //forward movement
            float moveSpeed = Input.GetTouch(0).position.y / Screen.height;
            transform.Translate(transform.forward * moveSpeed * speed * Time.deltaTime, Space.World);


            //rotation
            float rotateSpeed = Input.GetTouch(0).position.x / Screen.width - .5f;
            transform.Rotate(0, rotateSpeed * turnSpeed * Time.deltaTime, 0);
            anim.SetFloat("forwardMotion", Math.Max(moveSpeed, rotateSpeed));
        }

        if (IRefs.GetKeyDown(IRefs.Command.ToggleWalkThroughWalls))
            toggleDetectCollisions();

    }

    /**toggles ability to walk through walls*/
    public void toggleDetectCollisions() {
        detectCollisions = !detectCollisions;
        rb.isKinematic = !detectCollisions;
    }
}
