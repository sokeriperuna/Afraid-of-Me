using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerEntity))]
public class PlayerController : MonoBehaviour {

    private PlayerEntity player;
    private Camera viewCamera;

    private Vector3 inputVector;
    private Vector3 mousePositionInWorld;

    private void Awake()
    {
        player = GetComponent<PlayerEntity>();
        viewCamera = Camera.main;
    }

    private void FixedUpdate()
    {
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);
        mousePositionInWorld = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.z));
        player.CalculateMoveVelocity(inputVector);
        player.TurnToward(mousePositionInWorld);
        player.Move();
    }
}
