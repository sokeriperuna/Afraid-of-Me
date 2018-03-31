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

    public void TurnToward(Vector3 mousePosition, float turnSpeed)
    {
        float angle = Mathf.Atan(mousePosition.x / mousePosition.y) * Mathf.Rad2Deg;
        Debug.Log(angle.ToString());
        
        
        Debug.DrawLine(transform.position, mousePosition);
    }

}