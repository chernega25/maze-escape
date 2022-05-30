using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    static GameSession instance;

    static public GameSession GetSession() {
        return instance;
    }

    void Awake() {
        int instanceCount = FindObjectsOfType(GetType()).Length;
        if (instanceCount > 1) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
