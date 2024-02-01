using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour {

    private Rigidbody posChar;
    [SerializeField] private List<ParticleSystem> particulas;
    private Animator animator;

    public float speed = 5.0f;
    public float jumpHeight = 2.0f;
    public float gravity = -9.81f;
    [SerializeField] private float gravityMult = 2.0f;
    private float velocity;


    void Start() {
        posChar = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround()) {
            animator.SetInteger("Animation", 4);
            posChar.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Acceleration);
            posChar.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, +6.0f, Input.GetAxis("Vertical") * speed);
        }
    }

    void FixedUpdate() {

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        posChar.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, posChar.velocity.y, Input.GetAxis("Vertical") * speed);
        posChar.AddForce(new Vector3(0, gravity, 0), ForceMode.Acceleration);

        if (move.sqrMagnitude < 0.01f) {
            animator.SetInteger("Animation", 0);
            return;
        }

        if (move.magnitude > 0.01f) {
            bool isShiftDown = Input.GetKey(KeyCode.LeftShift);
            speed = isShiftDown ? 7.0f : 5.0f;
            animator.SetInteger("Animation", isShiftDown ? 2 : 1);

            transform.forward = Vector3.Slerp(transform.forward, move, Time.deltaTime * 10);
        }
    }

    private bool isOnGround() {
        return Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 0.1f);
    }
}
