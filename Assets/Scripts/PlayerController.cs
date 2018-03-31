using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerEntity))]
public class PlayerController : MonoBehaviour {

    private PlayerEntity player;
    private Camera viewCamera;

    private Vector3 inputVector;
    private Vector3 mousePositionInWorld;

    public float moveSpeed;
    public float turnSpeed;

    private void Awake()
    {
        player = GetComponent<PlayerEntity>();
        viewCamera = Camera.main;
    }

    private void Update()
    {
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);
        mousePositionInWorld = new Vector3 (viewCamera.ScreenToWorldPoint(Input.mousePosition).x, viewCamera.ScreenToWorldPoint(Input.mousePosition).y, 0f);
        player.CalculateVelocity(inputVector, moveSpeed);
        player.TurnToward(mousePositionInWorld, turnSpeed);
    }

    private void FixedUpdate()
    {
        player.Move();
    }
}
