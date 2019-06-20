using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryingPan_Base_Control : MonoBehaviour
{
    private List<GameObject> ColliderObjects = new List<GameObject>();

    // Update is called once per frame
    void FixedUpdate()
    {
        //other.transform.position = transform.position + transform.TransformDirection(0, 0, 1);
        foreach (var colliderObject in ColliderObjects)
        {
            if (colliderObject.tag == "burger_raw"
                || colliderObject.tag == "burger_cooked"
                || colliderObject.tag == "burger_burnt")
            {
                colliderObject.transform.parent = transform;
                colliderObject.transform.localPosition = new Vector3(0,1,0);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        ColliderObjects.Add(other.gameObject);
    }

    void OnTriggerExit(Collider other)
    {
        if (ColliderObjects.Contains(other.gameObject))
        {
            ColliderObjects.Remove(other.gameObject);
        }
    }
}
