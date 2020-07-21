using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] Vector3 startPos;
    [SerializeField] float spawnTime;

    internal List<Enemy> enemies;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            GameObject _newEnemy = Instantiate(enemy, startPos, Quaternion.identity, transform);
            //enemies.Add(_newEnemy.GetComponent<Enemy>());
            yield return new WaitForSeconds(spawnTime);
        }
    }

    public Enemy GetTarget(Tower tower)
    {
        Enemy target = null;
        foreach(Enemy enemy in enemies)
        {
            if(Vector2.Distance(enemy.transform.position, tower.transform.position) <= tower.range)
            {
                target = enemy;
            }
        }
        return target;
    }
}
