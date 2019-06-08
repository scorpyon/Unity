using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class OpenDoor : MonoBehaviour
{
    public Collider Hand = null;
    public List<Interactable> m_ContactInteractables = new List<Interactable>();
    
    public SteamVR_Action_Boolean m_GrabAction = null;
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;//which controller

    private Vector3 force;
    private Vector3 cross;
    private bool holdingHandle;
    private float angle;
    private const float forceMultiplier = 150f;

    public Vector3 DirectionToMoveTowards = new Vector3();

    private void Awake()
    {
    }

    private void Update()
    {
        // Down
        if (m_GrabAction.GetStateDown(inputSource) && Hand != null)
        {
            holdingHandle = true;
            print(inputSource + " Trigger Down");
        }

        //Up
        else if (m_GrabAction.GetStateUp(inputSource) && Hand != null)
        {
            holdingHandle = false;
            print(inputSource + " Trigger Up");
        }

        if(holdingHandle && Hand != null)
            MoveDoor();
    }

    public void MoveDoor()
    {
        DirectionToMoveTowards = Hand.transform.position - transform.position;



        
    }


    private Interactable GetNearestInteractable()
    {
        return null;
    }

    //public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;//which controller
    //private GameObject Hand { get; set; }
    //private Collider Collider { get; set; }

    //private Vector3 force;
    //private Vector3 cross;
    //private bool holdingHandle;
    //private float angle;
    //private const float forceMultiplier = 150f;

    //public void OnCollisionEnter(Collision collision)
    //{
    //    Collider = collision.collider;
    //    Debug.Log("Collision Triggered..");
    //    if (Collider == Hand)
    //    {
    //        Debug.Log("Collider was the Hand");
    //    }
    //}

    public void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Hand"))
        {
            Debug.Log("Trigger Entered..");
            if(Hand == null) Hand = otherCollider;
        }
    }

    public void OnTriggerExit(Collider otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Hand"))
        {
            Debug.Log("Trigger Exited..");
            Hand = null;
        }
    }

    void OnEnable()
    {
        //if (m_GrabAction != null)
        //{
        //    Hand = GameObject.Find(inputSource == SteamVR_Input_Sources.LeftHand ? SteamVR_Input_Sources.LeftHand.ToString() : SteamVR_Input_Sources.RightHand.ToString());
        //    if (Collider != null && Collider.gameObject == Hand)
        //    {
        //        Debug.Log("Grabbing....");
        //        m_GrabAction.AddOnChangeListener(OnTriggerPressedOrReleased, inputSource);
        //    }
        //}
    }

    //private void OnDisable()
    //{
    //    if (m_GrabAction != null)
    //    {
    //        m_GrabAction.RemoveOnChangeListener(OnTriggerPressedOrReleased, inputSource);
    //    }
    //}

    //private void OnTriggerPressedOrReleased(SteamVR_Action_Boolean triggerAction, SteamVR_Input_Sources actionSource, bool newState)
    //{
    //    holdingHandle = newState;

    //    if (holdingHandle)
    //    {
    //        holdingHandle = true;

    //        // Direction vector from the door's pivot point to the hand's current position
    //        Vector3 doorPivotToHand = Hand.transform.position - transform.parent.position;

    //        // Ignore the y axis of the direction vector
    //        doorPivotToHand.y = 0;

    //        // Direction vector from door handle to hand's current position
    //        force = Hand.transform.position - transform.position;

    //        // Cross product between force and direction. 
    //        cross = Vector3.Cross(doorPivotToHand, force);
    //        angle = Vector3.Angle(doorPivotToHand, force);
    //    }
    //    else
    //    {
    //        OnHandHoverEnd();
    //    }
    //}

    //public void Update()
    //{
    //    if (holdingHandle)
    //    {
    //        // Apply cross product and calculated angle to
    //        GetComponentInParent<Rigidbody>().angularVelocity = cross * angle * forceMultiplier;
    //    }
    //}

    //private void OnHandHoverEnd()
    //{
    //    // Set angular velocity to zero if the hand stops hovering
    //    GetComponentInParent<Rigidbody>().angularVelocity = Vector3.zero;
    //}
}
