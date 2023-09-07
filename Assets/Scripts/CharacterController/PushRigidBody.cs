using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushRigidBody : MonoBehaviour
{
    [SerializeField] private float pushPower;
    private float targetMass;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        if (body == null || body.isKinematic )
        {
            return;
        }

        if (hit.moveDirection.y <= -0.1) //Pregunta si el player esta golpiando hacia abajo al objeto;
        {
            return; //Para que no atraviece el piso.
        }

        targetMass = body.mass;

        Vector3 pushDirection = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        body.velocity = pushDirection * pushPower / targetMass;
    }
}
