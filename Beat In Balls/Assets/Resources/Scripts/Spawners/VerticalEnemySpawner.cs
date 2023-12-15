using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalEnemySpawner : EnemySpawner
{
    protected override Vector3 RandomizeLocation()
    {
        Vector3 newEnemyPosition;

        newEnemyPosition = playerTransform.up * Random.Range(-spawnBoxValue, spawnBoxValue);

        newEnemyPosition +=
            playerTransform.position +
            (playerTransform.right * playerDistance);

        return newEnemyPosition;
    }
}
