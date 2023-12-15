using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalEnemySpawn : EnemySpawner
{
    protected override Vector3 RandomizeLocation()
    {
        Vector3 newEnemyPosition;

        newEnemyPosition = playerTransform.right * Random.Range(-spawnBoxValue, spawnBoxValue);

        newEnemyPosition +=
            playerTransform.position +
            (playerTransform.up * playerDistance);

        return newEnemyPosition;
    }
}
