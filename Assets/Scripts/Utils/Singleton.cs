using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T _instance;
    public static T instance {
        get { 
            return _instance; 
        }
    }

    private void OnDestroy() {
        if (_instance == this) {
            _instance = null;
        }
    }

    public virtual void Awake() {
        if (_instance == null) {
            _instance = this as T;
        } else {
            Destroy(gameObject);
        }
    }
}

public class SingletonPersistent<T> : MonoBehaviour where T : Component
{
    private static T _instance;
    public static T instance {
        get { 
            return _instance; 
        }
    }

    private void OnDestroy() {
        if (_instance == this) {
            _instance = null;
        }
    }

    public virtual void Awake() {
        if (_instance == null) {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

}
