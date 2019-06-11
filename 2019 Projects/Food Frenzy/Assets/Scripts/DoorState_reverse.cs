using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Interactable))]
[RequireComponent(typeof(Rigidbody))]
public class DoorState_reverse : MonoBehaviour
{
    private Quaternion _yRotationOrigin;
    private float XAngle = 0.0f;
    private const float Smooth = 5.0f;

    void Start()
    {
        _yRotationOrigin = transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        XAngle = transform.rotation.x;
        if (XAngle > 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, _yRotationOrigin, Time.deltaTime * Smooth);
        }
        if (XAngle < 0.01)
        {
            var fixedJoint = GameObject.Find("RightHand").GetComponent<FixedJoint>();
            fixedJoint.connectedBody = null;
            
            transform.rotation = _yRotationOrigin;
        }
    }
}
