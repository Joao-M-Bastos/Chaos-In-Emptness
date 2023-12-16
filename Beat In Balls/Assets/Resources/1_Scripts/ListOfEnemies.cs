using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfEnemies : MonoBehaviour
{
    [SerializeField] GameObject[] enemiesAut;
    static GameObject[] enemies;

    private void Awake()
    {
        enemies = enemiesAut;
    }
    public static GameObject[] GetListOfEnemies()
    {
        return enemies;
    }
}
