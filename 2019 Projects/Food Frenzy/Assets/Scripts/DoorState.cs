using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Interactable))]
[RequireComponent(typeof(Rigidbody))]
public class DoorState : MonoBehaviour
{
    private Quaternion _yRotationOrigin;
    public float YAngle = 0.0f;
    private const float Smooth = 6.0f;
    private bool doorOpen = false;

    void Start()
    {
        _yRotationOrigin = transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        YAngle = transform.rotation.y;

        if (YAngle < -0.71)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, _yRotationOrigin, Time.deltaTime * Smooth);
            doorOpen = true;
        }
        if (YAngle > -0.71)
        {
            transform.rotation = _yRotationOrigin;
            YAngle = -0.7f;
            if (doorOpen)
            {
                GetComponent<CircularDrive>().outAngle = YAngle;
                doorOpen = false;
            }
        }
    }
}
