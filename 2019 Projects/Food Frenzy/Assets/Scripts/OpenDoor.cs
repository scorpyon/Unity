using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using Valve.VR;

public class OpenDoor : MonoBehaviour
{
    public GameObject DoorFrame = null;
    public List<GameObject> m_ContactHands = new List<GameObject>();
    public SteamVR_Action_Boolean m_GrabAction = null;
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;//which controller
    public Transform Parent = null;
    public GameObject GrippingHand = null;
    public bool holdingHandle;
    public Vector3 Hand = new Vector3();
    public float HandDistance;
    public float OldDistanceToFrame = 0.0f;
    public Transform InitialAttachPoint;
    private float DeltaMagic
    {
        get { return 1f; }
    }

    void Awake()
    {
        transform.parent.GetComponent<Rigidbody>().maxAngularVelocity = 100f;
    }

    private void FixedUpdate()
    {
        if (GrippingHand != null) Hand = GrippingHand.transform.position;

        GameObject handObject = null;

        //Is there an interaction?
        if (m_ContactHands.Count == 0)
        {
            holdingHandle = false;
        }
        else
        {
            // Down
            if (m_GrabAction.GetStateDown(inputSource) && m_ContactHands.Count > 0)
            {
                // Which hand is pulling the trigger?
                if (m_GrabAction.GetStateDown(SteamVR_Input_Sources.LeftHand))
                {
                    handObject = GameObject.Find("LeftHand");
                }
                else if (m_GrabAction.GetStateDown(SteamVR_Input_Sources.RightHand))
                {
                    handObject = GameObject.Find("RightHand");
                }

                if (handObject != null)
                {
                    // If not already holding the door handle then hold it now
                    if (GrippingHand == null)
                    {
                        GrippingHand = handObject;
                        holdingHandle = true;
                        InitialAttachPoint = GrippingHand.transform;
                    }
                }
            }
            //Up
            else if (m_GrabAction.GetStateUp(inputSource))
            {
                // Which hand is releasing the trigger?
                if (m_GrabAction.GetStateUp(SteamVR_Input_Sources.LeftHand))
                {
                    handObject = GameObject.Find("LeftHand");
                }
                else if (m_GrabAction.GetStateUp(SteamVR_Input_Sources.RightHand))
                {
                    handObject = GameObject.Find("RightHand");
                }

                if (GrippingHand != null && handObject == GrippingHand)
                {
                    holdingHandle = false;
                    GrippingHand = null;
                    OldDistanceToFrame = 0;
                    HandDistance = 0;
                    InitialAttachPoint = null;
                    GetComponentInParent<Transform>().GetComponentInParent<Rigidbody>().angularVelocity = Vector3.zero;
                }
            }
        }

        //// Distance from handle to Hand
        //if (GrippingHand != null)
        //{
        //    HandDistance = Vector3.Distance(DoorFrame.transform.position, GrippingHand.transform.position);
        //}

        
        if (holdingHandle && GrippingHand != null) 
            MoveDoor();
    }

    public void MoveDoor()
    {
        Vector3 PositionDelta = (GrippingHand.transform.position - InitialAttachPoint.position) * DeltaMagic;
        transform.parent.GetComponent<Rigidbody>().AddForceAtPosition(PositionDelta, InitialAttachPoint.position, ForceMode.VelocityChange);

        //if (newDistance >= HandleDistance)
        //{
        //    HandleDistance = newDistance;

        //    if (GrippingHand.transform.position.x > transform.position.x && GrippingHand.transform.position.z < transform.position.z)
        //    {
        //        Parent = transform.parent.parent;
        //        Parent.Rotate(0, 0, 2, Space.Self);
        //    }
        //    else if (GrippingHand.transform.position.x < transform.position.x && GrippingHand.transform.position.z > transform.position.z)
        //    {
        //        Parent = transform.parent.parent;
        //        Parent.Rotate(0, 0, -2, Space.Self);
        //    }
        //}

        //var smooth = 2.0f;
        //var movement = 0.0f;
        //if (HandDistance > OldDistanceToFrame)
        //{
        //    movement = -90.0f;
        //    OldDistanceToFrame = HandDistance;
        //}
        //Parent = transform.parent.parent;
        //GetComponentInParent<Transform>().GetComponentInParent<Rigidbody>().angularVelocity = Vector3.zero;
        //Parent.transform.localEulerAngles = new Vector3(
        //    Parent.transform.localEulerAngles.x, 
        //    Mathf.LerpAngle(Parent.transform.localEulerAngles.y, movement, Time.deltaTime * smooth),
        //    Parent.transform.localEulerAngles.z);
    }

    public void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Hand"))
        {
            m_ContactHands.Add(otherCollider.gameObject);
        }
    }

    public void OnTriggerExit(Collider otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Hand"))
        {
            m_ContactHands.Remove(otherCollider.gameObject);
        }
    }
}
