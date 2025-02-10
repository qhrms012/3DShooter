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
            SpawnEnemy(Random.Range(0, objectPool.enemy.Length)); // ������ �� ��ȯ
            yield return new WaitForSeconds(2f); // 2�ʸ��� ��ȯ
        }
    }

    void SpawnEnemy(int enemyIndex)
    {
        GameObject enemy = objectPool.Get(enemyIndex);
        enemy.transform.position = new Vector3(Random.Range(-5f, 5f), 0, Random.Range(5f, 10f));
    }
}