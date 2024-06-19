using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    FoodSpawner foodSpawner;

    int nutritionalValue = 10;

    public int GetEaten()
    {
        Destroy(gameObject);

        foodSpawner.SpawnFood();

        return nutritionalValue;
    }

    internal void Setup(FoodSpawner foodSpawner)
    {
        this.foodSpawner = foodSpawner;
    }
}
