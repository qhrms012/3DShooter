using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public ObjectPool objectPool;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            SpawnEnemy(Random.Range(0, objectPool.enemy.Length)); // 랜덤한 적 소환
            yield return new WaitForSeconds(2f); // 2초마다 소환
        }
    }

    void SpawnEnemy(int enemyIndex)
    {
        GameObject enemy = objectPool.Get(enemyIndex);
        enemy.transform.position = new Vector3(Random.Range(-5f, 5f), 0, Random.Range(5f, 10f));
    }
}