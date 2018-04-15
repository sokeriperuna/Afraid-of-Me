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
    public MirrorPath mirrorPath;

    private bool movingInPositiveDirection;
    private float startTime;
    private float journeyLength;
    private int currentIndex;
    private int targetIndex;

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
        }
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
