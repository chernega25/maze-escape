using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5f;

    Vector2 rawInput = new Vector2(0, 0);
    Rigidbody2D body;

    void Awake() {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    void Move() {
        body.velocity = rawInput * playerSpeed;
        // body.MovePosition(body.position + rawInput * playerSpeed);
        if (!body.velocity.Equals(Vector2.zero)) {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, body.velocity);
        }

    }

    void OnMove(InputValue value) {
        rawInput = value.Get<Vector2>();
    }
}
