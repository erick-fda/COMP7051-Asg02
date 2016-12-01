using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
    public float xSpeed = 5; //how fast the ball is moving along the x axis
    public float zSpeed = 0; // how fast the ball is moving along the z axis
    public float zSpeedExtent = .2f; // how much the ball moves along the z axis after hitting the baddle
    public GameController g; // the game controller object responsible for game management (scoring, input, game initialization)

	// Use this for initialization
	void Start () {
        zSpeedExtent = xSpeed * zSpeedExtent;
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * xSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * zSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision col) {
        if (col.collider.tag == "Paddle") {
            ContactPoint contact = col.contacts[0];
            xSpeed = -xSpeed;
            Vector3 contactPos = contact.point;
            zSpeed += (contactPos.z - col.transform.position.z) * zSpeedExtent;
            g.updateAIError();
        }
        if (col.collider.tag == "Wall")
        {
            zSpeed = -zSpeed;
        }
        if(col.collider.tag == "Out")
        {
            g.score();
        }
    }
}
