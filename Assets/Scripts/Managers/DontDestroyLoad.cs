using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyLoad : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}