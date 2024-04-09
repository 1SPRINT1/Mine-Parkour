
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraRotationPanel : MonoBehaviour, IPointerMoveHandler
{
    [SerializeField] Transform cameraTransform;
    [SerializeField] Transform PlayerTransform;
    [SerializeField] float Sensitivity;
    [SerializeField] float MaxAngleX;
    [SerializeField] float MinAngleX;
    [SerializeField] bool invert;
    private int FingerId = -1;
    bool isFingerMoving;
    Vector2 rotation;
    public void OnPointerMove(PointerEventData eventData)
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch t = Input.GetTouch(i);

            // Check each touch's phase
            switch (t.phase)
            {
                case TouchPhase.Began:
              //       if (FingerId == -1)
               //     {
                        // Start tracking the rightfinger if it was not previously being tracked
                        FingerId = t.fingerId;
                 //   }

                    break;
                case TouchPhase.Ended:
                case TouchPhase.Canceled:

                   
                 //    if (t.fingerId == FingerId)
                //    {
                        FingerId = -1;
                        isFingerMoving = false;
                 //   }

                    break;
                case TouchPhase.Moved:


                    // Get input for looking around
                    //      if (t.fingerId == FingerId)
                    //    {
                        rotation += t.deltaPosition * Sensitivity
                            * Time.deltaTime;
                        isFingerMoving = true;
               //     }
                   

                    break;
                case TouchPhase.Stationary:
                    // Set the look input to zero if the finger is still
                    if (t.fingerId == FingerId)
                    {
                        isFingerMoving = false;
                    }
                    break;
            }
        }
    
}
    void Start()
    {
         Cursor.lockState = CursorLockMode.None;
         Cursor.visible = true;
    }
    void Update()
    {
        if (FingerId != -1)
        {
            LookAround();
        }
    }
    void LookAround()
    {
        if (isFingerMoving)
        {
            if (rotation.y > MaxAngleX) rotation = new Vector2(rotation.x, MaxAngleX);
            if (rotation.y < MinAngleX) rotation = new Vector2(rotation.x, MinAngleX);
            if(invert)
            {
                rotation *= -1;
            }
            PlayerTransform.eulerAngles = new Vector3(0, -rotation.x, 0);
            cameraTransform.rotation = Quaternion.Euler(rotation.y, -rotation.x, 0);
        }
    }
    public void D()
    {
        Debug.Log("faafsafsafsafsaf");
    }
}
