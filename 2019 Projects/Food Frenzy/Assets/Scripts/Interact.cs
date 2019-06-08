using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Rigidbody))]
public class Interact : MonoBehaviour
{
    [HideInInspector] public Hand m_ActiveHand = null;
}
