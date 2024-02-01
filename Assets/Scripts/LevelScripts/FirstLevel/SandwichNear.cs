using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SandwichNear : MonoBehaviour {
    
    private FirstInitializer firstInitializer = new FirstInitializer();
    [SerializeField] private BoxCollider fredCollider;
    private BoxCollider boxCollider;

    void Awake() {
        boxCollider = GetComponent<BoxCollider>();    
    }

    void Start() {
        boxCollider.size = new Vector3(1.45f, 0.94f, 0.84f);
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            firstInitializer.addSandwich(1);
            Destroy(gameObject);
        }
    }
}
