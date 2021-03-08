using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleBehaviour<T> : MonoBehaviour where T:SingleBehaviour<T>
{
    private static SingleBehaviour<T> instance;
    public static T Instance
    {
        get
        {
            return (T)instance;
        }
    }
    public  void Awake()
    {
        instance = this;
        MyAwake();
    }
    public virtual void MyAwake()
    {

    }
}
