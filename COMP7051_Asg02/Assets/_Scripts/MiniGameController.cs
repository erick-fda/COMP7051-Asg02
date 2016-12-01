using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MiniGameController : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag.Equals("Player"))
            SceneManager.LoadScene("pongScene");
    }
}
