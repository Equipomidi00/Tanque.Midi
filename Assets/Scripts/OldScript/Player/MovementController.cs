using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [Header("Set Movement")]
    [SerializeField] private float speedForward;
    
    [Header("Set Rotation")]
    [SerializeField] private float speedRotate;

    private float rotateBody;
    private float moveForward;
   // private Rigidbody rb;
   // private Vector3 acceleration;

    private void Awake()
    {
        //rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        rotateBody = Input.GetAxisRaw("Horizontal");
        moveForward = Input.GetAxisRaw("Vertical");

        //acceleration.z = moveForward;
        //rb.AddForce(acceleration.normalized * speedForward, ForceMode.Acceleration); 

        transform.Translate(Vector3.forward * speedForward * Time.deltaTime * -moveForward);
        transform.Rotate(Vector3.up, rotateBody * speedRotate * Time.deltaTime);
    }
}