using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

    public GameObject doorObject;


    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter(Collider other) {
        doorObject.transform.Rotate(0, 90, 0);
    }

    void OnTriggerExit(Collider other) {
        doorObject.transform.Rotate(0, -90, 0);
    }
}
