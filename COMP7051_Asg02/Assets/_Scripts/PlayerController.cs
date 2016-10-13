using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    private Animator anim;
    private CharacterController controller;
    public float turnSpeed = 100;// how fast the character can turn
    public float walkSpeed = 5; //character walking speed
    public float runSpeed = 10;// character running speed
    private Rigidbody rb;
    private bool detectCollisions = true;

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
        if (anim == null)
            Debug.Log("no animator found on" + gameObject.name);
        controller = GetComponent<CharacterController>();
        if (anim == null)
            Debug.Log("no CharacterController found on" + gameObject.name);

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetAxis("Vertical") > .1)
            anim.SetFloat("forwardMotion", Input.GetAxis("Vertical"));
        else
            anim.SetFloat("forwardMotion", 0);

        bool isRunning = false;
        if (Input.GetAxis("Run") > 0)
            isRunning = true;

        anim.SetBool("run", isRunning);



        if(Input.GetAxis("Vertical") > 0 && !isRunning)
            transform.Translate(transform.forward * Input.GetAxis("Vertical") * walkSpeed * Time.deltaTime, Space.World);
        else if(Input.GetAxis("Vertical") > 0 && isRunning)
            transform.Translate(transform.forward * Input.GetAxis("Vertical") * runSpeed * Time.deltaTime, Space.World);

        if (Input.GetAxis("Horizontal") != 0) {
            transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);
            anim.SetFloat("forwardMotion", 1);
        }

        if (Input.GetKeyDown("u")) {
            Debug.Log("hi");
            detectCollisions = !detectCollisions;
            rb.isKinematic = !detectCollisions;
            
        }
        
    }
}
