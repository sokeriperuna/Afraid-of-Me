using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerEntity : MonoBehaviour {

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector3 input, float moveSpeed)
    {
        rb.MovePosition(transform.position + (input.normalized * moveSpeed * Time.deltaTime));
    }

    public void TurnToward(Vector3 mousePosition, float turnSpeed)
    {

    }

}