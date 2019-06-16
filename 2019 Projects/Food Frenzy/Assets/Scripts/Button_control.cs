using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_control : MonoBehaviour
{
    private Vector3 buttonPos;

    // Start is called before the first frame update
    void Start()
    {
        buttonPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > buttonPos.x + 0.04f)
            transform.position = new Vector3(buttonPos.x + 0.04f, transform.position.y, transform.position.z);
        else if (transform.position.x < buttonPos.x)
            transform.position = new Vector3(buttonPos.x, transform.position.y, transform.position.z);
    }
}
