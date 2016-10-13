using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    public Transform cameraOrigin;
    public float camRotationSpeed = 2;
    public float zoomSpeed = 20;
   
    private Vector3 offset;
    private Vector3 originalPos;
   
    // Use this for initialization
    void Start() {
        offset = transform.position - cameraOrigin.position;
        originalPos = cameraOrigin.InverseTransformPoint(transform.position);
       
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetAxis("Zoom") != 0) {
            transform.Translate(cameraOrigin.position * Input.GetAxis("Zoom") * zoomSpeed * Time.deltaTime);
            offset = transform.position - cameraOrigin.position;
            //offset = originalOffset;
        }
        
    }

    void LateUpdate() {

        if (Input.GetAxis("CamRotate") != 0) {
            offset = transform.position - cameraOrigin.position;
            offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * camRotationSpeed, Vector3.up) * offset;
            transform.position = cameraOrigin.position + offset;

            offset = Quaternion.AngleAxis(-Input.GetAxis("Mouse Y") * camRotationSpeed, Vector3.right) * offset;
            transform.position = cameraOrigin.position + offset;
            transform.LookAt(cameraOrigin.position);
        }
        else {
            transform.position = cameraOrigin.TransformPoint(originalPos);
            transform.LookAt(cameraOrigin.position);
        }
 
    }
}
