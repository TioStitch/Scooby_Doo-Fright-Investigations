using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    
    [SerializeField] private Transform charTransform;
    public float offDistance = 12.61f;
    public float offY = 2.83f;
    public float rotX = 20f;
    
    void Start() {
        transform.forward = charTransform.forward;
    }

    void Update() {
        Vector3 vector = new Vector3(0, offY, -offDistance);
        Quaternion newRotation = Quaternion.Euler(rotX, 0f, 0f);

        transform.position = Vector3.Slerp(transform.position, charTransform.position + newRotation * vector, Time.deltaTime * 10);

        transform.rotation = newRotation;
    }
}
