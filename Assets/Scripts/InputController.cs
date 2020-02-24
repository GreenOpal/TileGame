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
            if (Input.GetMouseButton(0))
            {
                Touch simulated = new Touch
                {
                    phase = TouchPhase.Moved,
                    position = Input.mousePosition
                };
                EventController.OnMouseDrag?.Invoke(simulated);
            }
            if (Input.GetMouseButtonUp(0))
            {
                Touch simulated = new Touch
                {
                    phase = TouchPhase.Ended,
                    position = Input.mousePosition
                };
                EventController.OnMouseUp?.Invoke(simulated);
            }
        } else
        {

        if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        EventController.OnMouseDown?.Invoke(touch);
                        break;
                    case TouchPhase.Moved:
                    case TouchPhase.Stationary:
                        EventController.OnMouseDrag?.Invoke(touch);
                        break;
                    case TouchPhase.Ended:
                    case TouchPhase.Canceled:
                        EventController.OnMouseUp?.Invoke(touch);

                        break;
                }
                
            }
        }
    }
}
