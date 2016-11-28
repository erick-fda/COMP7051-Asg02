using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
    /**the lifespan of the projectile before it self destructs*/
    public float lifeSpan = 2;

    /*how long the object has existed*/
    private float age = 0;

    /**The projectiles audio source. Used for bounce sound effects*/
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        age += Time.deltaTime;
        if(age > lifeSpan)
            Destroy(gameObject);

    }

    void OnCollisionEnter(Collision collision) {
        
        if (collision.gameObject.tag == "Enemy") {
            collision.gameObject.GetComponent<MonsterController>().takeDamge();
            Destroy(gameObject);
        }
        else {
            audioSource.Play();
        }
    }   
}