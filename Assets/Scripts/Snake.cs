using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField]
    SnakeMovement movement;
    [SerializeField]
    TailCreator tailCreator;

    public bool alive = true;

    [HideInInspector]
    List<Vector3> positionOverFrames;
    int positionsCapacity = 0;

    List<TailPart> tailParts = new List<TailPart>();

    private void FixedUpdate()
    {
        AddFrame();
    }

    private void Start()
    {
        positionOverFrames = new List<Vector3>();
        positionsCapacity = 10;
    }

    public int GetPositionListMaxLength()
    {
        return GetTailLength() * tailCreator.frameTimeBetweenTailParts;
    }

    void AddFrame()
    {
        positionOverFrames.Add(transform.position);
        if (positionOverFrames.Count >= positionsCapacity)
        {
            positionOverFrames.RemoveAt(0);
        }
    }

    public void IncreasePositionsListCapacity(int addedCapacity)
    {
        positionsCapacity += addedCapacity;
    }

    public void Die()
    {
        Debug.Log("dead");

        alive = false;

        PlayerUI.Instance.ShowDeathScreen();
    }

    public void Grow()
    {
        tailParts.Add(tailCreator.CreateTail(this));

        IncreasePositionsListCapacity(tailCreator.frameTimeBetweenTailParts);
    }

    public int GetTailLength()
    {
        return tailParts.Count;
    }


    private void OnCollisionEnter(Collision collision)
    {
        CollidedWith(collision.gameObject);
    }

    public void CollidedWith(GameObject otherObject)
    {
        int collisionLayer = otherObject.layer;

        if (collisionLayer == Layers.OBSTACLE || collisionLayer == Layers.TAIL_PART)
        {
            TailPart tailPart = otherObject.GetComponent<TailPart>();

            if (tailPart == null || tailPart.CouldKill())
            {
                Die();
            }
        }
        else if (collisionLayer == Layers.FOOD)
        {
            int growAmount = otherObject.GetComponent<Food>().GetEaten();

            for (int i = 0; i < growAmount; i++)
            {
                Grow();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        CollidedWith(other.gameObject);
    }

    public Vector3 GetPositionXFramesAgo(int x)
    {
        int positionsLength = positionOverFrames.Count;

        int desiredPositionIndex = positionsLength - x;

        if (desiredPositionIndex >= 0)
        {
            return positionOverFrames[desiredPositionIndex];
        }
        else
        {
            return positionOverFrames[0];
        }
    }
}
