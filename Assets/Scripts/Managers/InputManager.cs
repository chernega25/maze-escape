using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] InteractionHandler interactionHandler;

    Camera cameraMain;

    Vector2 deltaMove = new Vector2();
    Vector2 screenPosition = new Vector2();
    bool hold = false;
    Coroutine holdCoroutine;

    void Awake() {
        cameraMain = Camera.main;
    }

    void OnMouseClick() {
        Interation(screenPosition);
    }

    void OnMouseHold(InputValue value) {
        if (value.isPressed) {
            holdCoroutine = StartCoroutine(MouseHoldCoroutine());
        } else {
            if (holdCoroutine != null) {
                StopCoroutine(holdCoroutine);
            }
            hold = false;
        }
    }

    IEnumerator MouseHoldCoroutine() {
        yield return new WaitForSeconds(0.2f);
        hold = true;
        holdCoroutine = null;
    }

    void OnKeyboardMove(InputValue value) {
        deltaMove = value.Get<Vector2>();
    }

    void UpdateVelocity() {
        if (playerMovement != null) playerMovement.UpdateVelocity(hold ? cameraMain.ScreenToWorldPoint(screenPosition) : deltaMove, hold);
    }

    void Interation(Vector2 position) {
        if (interactionHandler != null) interactionHandler.Interaction(cameraMain.ScreenToWorldPoint(position));
    }

    void ScreenPosition() {
        Touchscreen touchscreen = Touchscreen.current;
        Mouse mouse = Mouse.current;
        if (touchscreen != null) {
            screenPosition = touchscreen.primaryTouch.position.ReadValue();
        } else if (mouse != null) {
            screenPosition = mouse.position.ReadValue();
        }
    }

    void Update() {
        ScreenPosition();
        UpdateVelocity();
    }


}
