using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Interactable))]
[RequireComponent(typeof(Rigidbody))]
public class DoorState_reverse : MonoBehaviour
{
    private Quaternion _yRotationOrigin;
    private float XAngle = 0.0f;
    private const float Smooth = 6.0f;
    private bool doorOpen = false;

    void Start()
    {
        _yRotationOrigin = transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        XAngle = transform.rotation.x;

        if (XAngle > 0.008)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, _yRotationOrigin, Time.deltaTime * Smooth);
            doorOpen = true;
        }
        if (XAngle < 0.008)
        {
            transform.rotation = _yRotationOrigin;
            XAngle = 0;
            if (doorOpen)
            {
                GetComponent<CircularDrive>().outAngle = XAngle;
                doorOpen = false;
            }
        }
    }
}
