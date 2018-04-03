using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerEntity : MonoBehaviour {

    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private Vector3 turnVelocity;

    public float moveSpeed;
    public float turnSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void CalculateMoveVelocity(Vector3 input)
    {
        moveVelocity = input.normalized * moveSpeed;
    }

    public void Move()
    {
        rb.MovePosition (rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    Quaternion CalculateLookRotation(Vector3 mousePositionInWorld)
    {
        float angleToMouse = Vector2.SignedAngle(transform.up, mousePositionInWorld - transform.position);
        Quaternion lookRotation = new Quaternion();
        lookRotation.eulerAngles = new Vector3(0f, 0f, transform.rotation.eulerAngles.z + angleToMouse);
        return lookRotation;
    }

    public void TurnToward(Vector3 target)
    {
        Quaternion newRotation = new Quaternion();
        newRotation.eulerAngles = new Vector3(0f, 0f, rb.rotation + Vector2.SignedAngle(transform.up, target - transform.position) * turnSpeed * Time.fixedDeltaTime);
        transform.rotation = newRotation;
    }

}