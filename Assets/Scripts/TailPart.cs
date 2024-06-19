using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailPart : MonoBehaviour
{
    [SerializeField]
    int frameTimeBias;

    Snake snake;

    public int tailIndex { get; private set; }

    public bool movedSinceStart { get; private set; }

    Vector3 startingPosition;

    public void Setup(Snake snake, int frameTimeBias)
    {
        this.snake = snake;
        this.frameTimeBias = frameTimeBias;

        tailIndex = snake.GetTailLength();
    }

    private void Start()
    {
        movedSinceStart = false;

        transform.position = snake.GetPositionXFramesAgo(frameTimeBias);

        startingPosition = transform.position;
    }

    private void FixedUpdate()
    {
        transform.position = snake.GetPositionXFramesAgo(frameTimeBias);

        movedSinceStart = movedSinceStart || startingPosition != transform.position;
    }

    public bool CouldKill()
    {
        return movedSinceStart && tailIndex > 1;
    }
}
