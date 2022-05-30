using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    [SerializeField] GameObject doorClosed;
    [SerializeField] GameObject doorOpened;

    void Start()
    {
        doorClosed.SetActive(true);
        doorOpened.SetActive(false);
    }

    public void Interact() {
        doorClosed.SetActive(!doorClosed.activeSelf);
        doorOpened.SetActive(!doorOpened.activeSelf);
    }
}
