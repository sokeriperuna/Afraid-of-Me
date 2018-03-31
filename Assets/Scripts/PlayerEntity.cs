using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerEntity : MonoBehaviour {

    private Rigidbody2D rb;
    private Vector2 velocity;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void CalculateVelocity(Vector3 input, float moveSpeed)
    {
        velocity = input.normalized * moveSpeed;
    }

    public void Move()
    {
        rb.MovePosition (rb.position + velocity * Time.fixedDeltaTime);
    }

    Quaternion CalculateLookRotation(Vector3 mousePositionInWorld)
    {
        float angleToMouse = Vector2.SignedAngle(transform.up, mousePositionInWorld - transform.position);

        Quaternion lookRotation = new Quaternion();
        lookRotation.eulerAngles = new Vector3(0f, 0f, transform.rotation.eulerAngles.z + angleToMouse);
        return lookRotation;
    }

    public void TurnToward(Vector3 mousePositionInWorld, float turnSpeed)
    {
        transform.rotation = CalculateLookRotation(mousePositionInWorld);
    }

}