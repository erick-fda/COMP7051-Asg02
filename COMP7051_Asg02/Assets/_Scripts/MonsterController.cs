using UnityEngine;
using System.Collections;

/**Controls the movement of the NPC monster*/
public class MonsterController : MonoBehaviour {
   /**monster turning speed*/
    public float turnSpeed = 100;

    /**monster walking speed*/
    public float walkSpeed = 5;

    /**how long the monster continues to turn after it is no longer colliding with an object*/
    public float turningTime = 1;

    /** the direction to turn in positive = right negetive = left. This is set in OnCollisionStay()*/
    private float turnDirection = 1;

    /**time since the object has last collided with something*/
    private float timeSinceCollision = 99999;

    /**determines if the object is moving forward. Used with the animator*/
    private float forwardMotion = 1;

    /**the animator that controlls the monstor's animations*/
    private Animator anim;

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        turningControl();

        //if the monster should be moving forward, move it and get the animator to animate walding
        if (forwardMotion >  0)        
            transform.Translate(transform.forward * forwardMotion * walkSpeed * Time.deltaTime, Space.World);

        anim.SetFloat("forwardMotion", forwardMotion);
    }

    /**handles the turning the monster*/
    private void turningControl() {
        timeSinceCollision += Time.deltaTime;
        float turn = 0;
        if (timeSinceCollision < turningTime)
            turn = 1;
        else
            turn = 0;

        anim.SetFloat("turn", turn);
        transform.Rotate(0, turnDirection * turn * turnSpeed * Time.deltaTime, 0);
    }

    /**called while the object is colliding with another*/
    void OnCollisionStay(Collision collisionInfo) {
        timeSinceCollision = 0;
        anim.SetFloat("turn", 1);

        //gets the local coordinates of the first point of contact detected in the collision
        Vector3 firstContactLocal = transform.InverseTransformPoint(collisionInfo.contacts[0].point);
        if (firstContactLocal.x > 0)
            turnDirection = -1;
        else if(firstContactLocal.x < 0) 
            turnDirection = 1;
    }

}
