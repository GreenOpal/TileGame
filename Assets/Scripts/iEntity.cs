using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iEntity : MonoBehaviour
{
    protected virtual void Setup() { }


    void Start()
    {
        transform.SetX(5);
    }
    
}

