using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private void Awake()
    {
        
    }

    private void Update()
    {
        if (Application.isEditor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Touch simulated = new Touch
                {
                    phase = TouchPhase.Began,
                    position = Input.mousePosition
                };
                EventController.OnMouseDown?.Invoke(simulated);
            }
        } else
        {

        if (Input.touchCount > 0)
            {
                EventController.OnMouseDown?.Invoke(Input.GetTouch(0));
            }
        }
    }
}
