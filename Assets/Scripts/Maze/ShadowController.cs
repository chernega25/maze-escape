using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowController : MonoBehaviour
{
    [SerializeField] GameObject shadowTop;
    [SerializeField] GameObject shadowBottom;
    [SerializeField] GameObject shadowLeft;
    [SerializeField] GameObject shadowRight;

    public void InitializeShadows(bool top, bool bottom, bool left, bool right) {
        shadowTop.SetActive(top);
        shadowBottom.SetActive(bottom);
        shadowLeft.SetActive(left);
        shadowRight.SetActive(right);
    }

    // public void ChangeRight()
}
