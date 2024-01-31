using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T instance
    {

        private set;
        get;
    }
    private void Awake()
    {
        if (instance == null)
            instance = (T)(MonoBehaviour)this;
        OnAwake();
    }
    public virtual void OnAwake() { }
    private void Reset()
    {
        gameObject.name = typeof(T).Name;
    }
}
public class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance_;
    public static T instance
    {
        get
        {
            if (SingletonMono<T>.instance_ == null)
            {
                SingletonMono<T>.instance_ = (T)FindObjectOfType(typeof(T));
                if (SingletonMono<T>.instance_ == null)
                {
                    GameObject go = new GameObject();
                    go.name = "[@" + typeof(T).Name + "]";
                    SingletonMono<T>.instance_ = go.AddComponent<T>();
                }

            }
            return SingletonMono<T>.instance_;
        }
    }
    private void Reset()
    {
        gameObject.name = typeof(T).Name;
    }
}