using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemySpawner : MonoBehaviour
{
    [SerializeField] float cooldownValue;

    [SerializeField] protected float spawnBoxValue;

    [SerializeField] protected float playerDistance;

    protected GameObject[] enemyList; 

    protected Transform playerTransform;

    public bool canSpawn;

    // Update is called once per frame
    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        enemyList = ListOfEnemies.GetListOfEnemies();
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
        int listIndex = Random.Range(0, enemyList.Length);

        Instantiate(enemyList[listIndex], RandomizeLocation(), enemyList[listIndex].transform.rotation);
    }

    protected abstract Vector3 RandomizeLocation();

}
