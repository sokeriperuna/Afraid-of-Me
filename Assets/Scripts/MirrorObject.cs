using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct MirrorPath
{
    public bool loops;
    public Transform[] nodes;
}

public class MirrorObject : MonoBehaviour
{

    public bool moving;
    public float moveSpeed;
    public float turnSpeed;
    public MirrorPath mirrorPath;

    private bool movingInPositiveDirection;

    private float startTime;
    private float journeyLength;

    private int currentIndex;
    private int targetIndex;

    private Vector3 lastPosition;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        movingInPositiveDirection = true;
        startTime = Time.time;
        if (mirrorPath.nodes != null && mirrorPath.nodes.Length >= 2)
        {
            journeyLength = Vector3.Distance(mirrorPath.nodes[0].position, mirrorPath.nodes[1].position);
            transform.position = mirrorPath.nodes[0].position;
            currentIndex = 0;
            targetIndex  = 1;
        }
    }

    public void FixedUpdate()
    {
        if (moving && mirrorPath.nodes.Length >= 2)
        {
            Lerp();

            Vector3 movementDelta = lastPosition - transform.position;
            TurnToward(transform.position - movementDelta);
        }

        lastPosition = transform.position;
    }

    void Lerp()
    {
        float dstCovered   = (Time.time - startTime) * moveSpeed;
        float fracJourney  = dstCovered / journeyLength;
        transform.position = Vector3.Lerp(mirrorPath.nodes[currentIndex].position,
                                          mirrorPath.nodes[targetIndex].position, 
                                          fracJourney);
        if (fracJourney >= 1f)
            SetNextTarget();
    }

    public void TurnToward(Vector3 target)
    {
        Quaternion newRotation = new Quaternion();
        newRotation.eulerAngles = new Vector3(0f, 0f, rb.rotation + Vector2.SignedAngle(transform.up, target - transform.position) * turnSpeed * Time.fixedDeltaTime);
        transform.rotation = newRotation;
    }

    void SetNextTarget()
    {
        currentIndex = targetIndex;
        targetIndex++;
        if (targetIndex >= mirrorPath.nodes.Length)
        {
            if (mirrorPath.loops)
                targetIndex = 0;
            else
            {
                movingInPositiveDirection = false;
                targetIndex = mirrorPath.nodes.Length - 2;
            }
        }

        startTime = Time.time;
        journeyLength = Vector3.Distance(mirrorPath.nodes[currentIndex].position, mirrorPath.nodes[targetIndex].position);
    }

}
