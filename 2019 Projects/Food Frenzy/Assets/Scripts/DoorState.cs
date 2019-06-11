using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Interactable))]
[RequireComponent(typeof(Rigidbody))]
public class DoorState : MonoBehaviour
{
    private Quaternion _yRotationOrigin;
    private float YAngle = 0.0f;
    private const float Smooth = 2.0f;

    void Start()
    {
        _yRotationOrigin = transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        YAngle = transform.rotation.y;

        if (YAngle < 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, _yRotationOrigin, Time.deltaTime * Smooth);
        }
        if (YAngle > -0.01)
        {
            transform.rotation = _yRotationOrigin;
        }
    }
}
