using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterMovementIA : MonoBehaviour {

    private Rigidbody posChar;
    private Animator animator;
    public float speed = 5.0f;

    [SerializeField] private List<GameObject> pontos;
    private int walkedPlaces = 0;


    void Start() {
        posChar = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update() {
        if (DentroDoEspaco(0)) {
            print("Dentro do 1");
        }
    }

    public bool DentroDoEspaco(int ponto) {
        float X = Math.Abs(pontos[ponto].transform.position.x - gameObject.transform.position.x);
        float Z = Math.Abs(pontos[ponto].transform.position.z - gameObject.transform.position.z);

        return X < 1.5f && Z < 1.5f;
    }

void FixedUpdate() {
    Vector3 move = new Vector3(0, 0, 0);
    posChar.velocity = getVectorAt();

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
    print(walkedPlaces);
}
    private Vector3 getVectorAt() {
        float y = 0f;
        Vector3 vectorNull = new Vector3(0, y, 0);

        switch (walkedPlaces) {
            case 1:
                transform.forward = Vector3.Slerp(transform.forward, new Vector3(-120.0f, 0, 0), Time.deltaTime * 10);
            break;
            case 2:
                transform.forward = Vector3.Slerp(transform.forward, new Vector3(-90.0f, 0, 0), Time.deltaTime * 10);
            break;
            case 3:
                transform.forward = Vector3.Slerp(transform.forward, new Vector3(-120.0f, 0, 0), Time.deltaTime * 10);
            break;
        }

        if (DentroDoEspaco(walkedPlaces)) {
            if (walkedPlaces <= 3) {
                walkedPlaces += 1;
            }
        }

        if (!DentroDoEspaco(walkedPlaces)) {
            switch (walkedPlaces) {
                case 1:
                return new Vector3(-1.5f * speed, y, 0);
                case 2:
                return new Vector3(0, y, -1.5f * speed);
                case 3:
                return new Vector3(-1.5f * speed, y, 0);
            }
            return new Vector3(0, y, 1.5f * speed);
        }

        //Dentro do Cubo:
        //Ele vai adicionar +1 WalkedPlace e
        //só retornará a adicionar quando estiver
        //dentro do próximo cubo.
        walkedPlaces += 1;

        
        return vectorNull;
    }

    //private float getMoveAt() {
    //    
    //    Vector3 monsterPonto = gameObject.transform.position;
    //    Vector3 vetorPonto = pontos[walkedPlaces].transform.position;
//
    //    if (vetorPonto.z <= monsterPonto.z && vetorPonto.x <= monsterPonto.x) {
    //        walkedPlaces = 1;
    //        return 0f;
    //    }
//
   //     switch (walkedPlaces) {
   //         case 0:
   //             walkedPlaces = 1;
   //         return 1.5f;
   //         case 1:
   //             transform.forward = Vector3.Slerp(transform.forward, new Vector3(30.0f, 0, 0), Time.deltaTime * 10);
   //         return 1.5f;
   //     }
   //     return 1.5f;
   // }
}