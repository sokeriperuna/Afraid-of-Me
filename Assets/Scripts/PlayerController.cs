using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerEntity))]
public class PlayerController : MonoBehaviour {

    private PlayerEntity player;

    private Vector3 inputVector;
    private Vector3 mousePositionInWorld;

    public float moveSpeed;
    public float turnSpeed;

    private void Awake()
    {
        player = GetComponent<PlayerEntity>();
    }

    private void Update()
    {
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);
        mousePositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        player.Move(inputVector, moveSpeed);
        player.TurnToward(mousePositionInWorld, turnSpeed);
    }
}
