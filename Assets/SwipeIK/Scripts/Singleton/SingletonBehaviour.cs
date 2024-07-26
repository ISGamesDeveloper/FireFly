using UnityEngine;
using System.Collections;

public class SingletonBehaviour<T> : MonoBehaviour where T : SingletonBehaviour<T>
{
    static T _s;
     
    public static T instance 
    {
        get
        {
            if (_s == null)
            {
                _s = FindObjectOfType<T>() as T;
            }
            return _s;
        }
    }
}