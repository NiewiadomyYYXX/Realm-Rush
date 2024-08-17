using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] int poolSize = 5;
    [SerializeField] float spawnTimer = 1f;

    GameObject[] pool;

    void Awake()
    {
        PopulatePool();
    }

    void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for (int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab);
            pool[i].SetActive(false);
        }
    }

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }

    void EnableObjectInPool()
    {
        for (int i = 0; i < pool.Length; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }

}
