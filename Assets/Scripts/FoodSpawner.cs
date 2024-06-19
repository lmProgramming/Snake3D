using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject foodPrefab;
    public Transform foodHolder;

    public Vector2 xSpawnRange;
    public Vector2 ySpawnRange;
    public Vector2 zSpawnRange;

    private void Start()
    {
        SpawnFood();
    }

    public void SpawnFood()
    {
        GameObject foodObject = Instantiate(foodPrefab, foodHolder);

        Vector3 newPosition = new Vector3(Random.Range(xSpawnRange.x, xSpawnRange.y),
                                          Random.Range(ySpawnRange.x, ySpawnRange.y),
                                          Random.Range(zSpawnRange.x, zSpawnRange.y));

        foodObject.transform.position = newPosition;

        foodObject.GetComponent<Food>().Setup(this);
    }
}
