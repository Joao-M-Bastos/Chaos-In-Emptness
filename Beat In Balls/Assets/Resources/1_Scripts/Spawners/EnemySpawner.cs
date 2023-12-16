using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemySpawner : MonoBehaviour
{
    [SerializeField] float cooldownValue;

    [SerializeField] protected float spawnBoxValue;

    [SerializeField] protected float playerDistance;

    protected Transform playerTransform;

    public bool canSpawn;

    // Update is called once per frame
    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(SpawnEnemies());
    }

    public IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(Random.Range(cooldownValue/2, cooldownValue));
        if(canSpawn) SpawnRandomEnemy();
        StartCoroutine(SpawnEnemies());
    }

    private void SpawnRandomEnemy()
    {
        GameObject randomEnemy = ListOfEnemies.GetRandomEnemy();

        Instantiate(randomEnemy, RandomizeLocation(), randomEnemy.transform.rotation);
    }

    protected abstract Vector3 RandomizeLocation();

}
