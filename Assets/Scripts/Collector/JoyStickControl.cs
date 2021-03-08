using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickControl : MonoBehaviour
{
    public float Result
    {
        get
        {
            return result;
        }
    }
    private float result;

    private float minMoveDistance;
    private float maxDistance;
    private Vector3 firstPos;
  
   
  

    public void Start()
    {
        minMoveDistance = Mathf.Sqrt(Screen.width * Screen.height) * 0.05f;
        maxDistance = minMoveDistance * 3;

    }
    public void Update()
    {
        switch (Application.platform)
        {
            case RuntimePlatform.Android:
            case RuntimePlatform.IPhonePlayer:
                if (Input.touchCount > 0)
                {
                    Touch item = Input.GetTouch(0);
                    switch (item.phase)
                    {
                        case TouchPhase.Began:
                            firstPos = item.position;
                           
                          

                            break;
                        case TouchPhase.Moved:
                            float xdist = item.position.x - firstPos.x;
                            if (Mathf.Abs(xdist) > minMoveDistance)
                            {
                                result = Mathf.Clamp(xdist / maxDistance, -1, 1);
                                firstPos = Input.mousePosition;
                            }

                           

                            break;
                        case TouchPhase.Ended:
                        case TouchPhase.Canceled:
                            result = 0;
                            break;
                    }
                }
                break;
            default:
                if (Input.GetMouseButtonDown(0))
                {
                    firstPos = Input.mousePosition;
                   
                   
                }
                else if (Input.GetMouseButton(0))
                {
                    float xdist = Input.mousePosition.x - firstPos.x;

                    if (Mathf.Abs(xdist) > minMoveDistance)
                    {
                        result = Mathf.Clamp(xdist / maxDistance, -1, 1);
                        firstPos = Input.mousePosition;

                    }

                  
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    result = 0;
                }
                break;
        }


    }

}
