using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(FieldOfView))]
public class PlayerEntity : MonoBehaviour {

    private Rigidbody2D rb;
    private FieldOfView fov;

    private Vector2 moveVelocity;

    private float lastMirrorBufferCalculation;

    public float moveSpeed;
    public float turnSpeed;

    public float mirrorBufferMax;
    public float mirrorBufferDecay;
    public float mirrorBufferGain;
    public float mirrorBuffer;

    public delegate void PlayerDelegate();
    public event PlayerDelegate mirrorBufferUpdated;
    public static event PlayerDelegate playerFailure;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        fov = GetComponent<FieldOfView>();
        fov.targetsFound += CalculateMirrorBufferTargets;
    }

    private void Start()
    {
        lastMirrorBufferCalculation = Time.time;
    }

    private float CalculateMirrorBufferAddition(Transform mirror)
    {
        Vector2 playerToMirror = (mirror.position - transform.position).normalized;
        float angle = Vector2.Angle(transform.up, playerToMirror);
        float anglePercent = 1f - (angle / (fov.viewAngle / 2));

        return (Time.time - lastMirrorBufferCalculation) * anglePercent * mirrorBufferGain;
    }

    public void CalculateMoveVelocity(Vector3 input)
    {
        moveVelocity = input.normalized * moveSpeed;
    }

    public void CalculateMirrorBufferTargets()
    {
        float bufferSum = 0;
        foreach (Transform target in fov.visibleTargets)
            if (target.CompareTag("Mirror"))
                bufferSum += CalculateMirrorBufferAddition(target);

        mirrorBuffer += (bufferSum - (Time.time - lastMirrorBufferCalculation) * mirrorBufferDecay);

        if (mirrorBuffer < 0f)
            mirrorBuffer = 0f;
        else if (mirrorBuffer > mirrorBufferMax)
            if (playerFailure != null)
                playerFailure();

        lastMirrorBufferCalculation = Time.time;

        if(mirrorBufferUpdated != null)
            mirrorBufferUpdated();
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