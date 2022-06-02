using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.InputSystem;


public class InteractionHandler : MonoBehaviour
{

    private void Awake() {
    }

    public void Interaction(Vector2 position) {

        foreach (Collider2D collider in Physics2D.OverlapPointAll(position)) {
            switch (collider.gameObject.tag)
            {
                case "Door":
                    DoorInteract(collider.gameObject);
                    return;
                default:
                    continue;
            }
        }
    }
    
    void DoorInteract(GameObject gameObject) {
        gameObject.GetComponent<DoorInteraction>().Interact();
    }
}