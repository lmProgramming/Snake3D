using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailCreator : MonoBehaviour
{
    [SerializeField]
    GameObject tailPrefab;

    [SerializeField]
    Transform tailHolder;

    [SerializeField]
    public int frameTimeBetweenTailParts = 120;

    public int CalculateFrameTimeBias(int tailLength)
    {
        return frameTimeBetweenTailParts * (tailLength + 1);
    }

    public TailPart CreateTail(Snake snake)
    {
        GameObject tailObject = Instantiate(tailPrefab, tailHolder);

        tailObject.transform.rotation = Quaternion.identity;

        TailPart tail = tailObject.GetComponent<TailPart>();

        int frameTimeBias = CalculateFrameTimeBias(snake.GetTailLength());

        tail.Setup(snake, frameTimeBias);

        return tail;
    }
}
