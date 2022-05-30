using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InteractionHandler : MonoBehaviour
{
    void OnInteract() {
        Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Debug.Log(clickPosition.ToString());

        foreach (Collider2D collider in Physics2D.OverlapPointAll(clickPosition)) {
            Debug.Log(collider.gameObject.tag);
            switch (collider.gameObject.tag)
            {
                case "Door":
                    DoorInteract(collider.gameObject);
                    continue;
                default:
                    continue;
            }
        }
    }

    
    void DoorInteract(GameObject gameObject) {
        gameObject.GetComponent<DoorInteraction>().Interact();
    }
}