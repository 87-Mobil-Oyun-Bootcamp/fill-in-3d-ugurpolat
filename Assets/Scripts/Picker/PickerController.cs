using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickerController : MonoBehaviour
{
    [Space]
    [SerializeField]
    private float speed = 1f;

    Vector3 firstTouchPos = Vector3.zero;
    Vector3 deltaTouchPos = Vector3.zero;
    Vector3 targetDirection = Vector3.zero;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstTouchPos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            deltaTouchPos = Input.mousePosition - firstTouchPos;
            targetDirection = new Vector3(deltaTouchPos.x, 0f, deltaTouchPos.y);
            rb.velocity = targetDirection.normalized * speed;

            rb.rotation = Quaternion.LookRotation(rb.velocity);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }


}
