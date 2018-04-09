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

    private float startTime;
    private float journeyLength;
    private int targetIndex;

    private void Start()
    {
        targetIndex = 0;
        startTime = Time.time;
        if (mirrorPath.nodes != null && mirrorPath.nodes.Length >= 2)
        {
            journeyLength = Vector3.Distance(mirrorPath.nodes[0].position, mirrorPath.nodes[1].position);
        }
    }

    public void FixedUpdate()
    {
        if (moving && mirrorPath.nodes.Length >= 2)
        {
            LerpTowardTarget(mirrorPath.nodes[targetIndex]);
        }
    }

    void LerpTowardTarget(Transform target)
    {


    }
}
