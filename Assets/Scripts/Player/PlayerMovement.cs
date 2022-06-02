using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5f;

    Rigidbody2D body;
    Vector2 delta;

    void Awake() {
        body = GetComponent<Rigidbody2D>();
    }

    void Update() {
        Move();
    }

    void Move() {
        body.velocity = playerSpeed * delta;
        RotateBody();
    }

    void RotateBody() {
        if (!body.velocity.Equals(Vector2.zero)) {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, body.velocity);
        }
    }

    public void UpdateVelocity(Vector2 input, bool target) {
        if (target) {
            Vector2 moveVector = input - new Vector2(transform.position.x, transform.position.y);
            if (moveVector.magnitude > 0.5f) {
                delta = moveVector.normalized;
            } else {
                delta = Vector2.zero;
            }
        } else {
            delta = input; 
        }
    }

}
