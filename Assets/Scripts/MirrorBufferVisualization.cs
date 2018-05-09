using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorBufferVisualization : MonoBehaviour {

    private SpriteRenderer spriteRenderer;

    private Vector3 currentOffset;

    public PlayerEntity player;

    public Vector2 defOffset;

    public Sprite[] indicatorSprites;
    public Vector3[] indicatorOffsets;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player.mirrorBufferUpdated += OnMirrorBufferUpdate;
        currentOffset = defOffset;
    }

    public void OnMirrorBufferUpdate()
    {
        if (player.mirrorBuffer == 0)
        {
            spriteRenderer.sprite = indicatorSprites[0];
            currentOffset = (Vector3)defOffset;
        }
        else
        for (int i = 0; i < 8; i++)
        {
            if (CompareMBFraction(i))
            {
                SetIndicator(i);
            }
        }
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position + currentOffset;
    }

    bool CompareMBFraction(float input)
    {
        bool output = false;
        if(input != 0)
            output = (player.mirrorBuffer > ((player.mirrorBufferMax / 8f) * input));
        return output;
    }

    public void SetIndicator(int index)
    {
        if (index < 0 || index > 7)
            spriteRenderer.sprite = null;
        else
        {
            spriteRenderer.sprite   = indicatorSprites[index];
            currentOffset = ((Vector3)defOffset) + indicatorOffsets[index];
            transform.position = player.transform.position + currentOffset;
        }
    }
}
