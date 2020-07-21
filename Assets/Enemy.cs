using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health, speed;

    bool alive = true;

    void Start()
    {
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        int pahtStep = 0;
        Vector3 currentTarget = PathController.instance.path[pahtStep];
        while (alive)
        {
            yield return null;
            transform.position =  Vector2.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
            if(Vector2.Distance(currentTarget, transform.position) < 0.01f)
            {
                pahtStep++;
                currentTarget = PathController.instance.path[pahtStep];
            }
        }
    }

    public void DealDamage(float _damage)
    {
        health -= _damage;
        if(health <= 0)
        {
            EnemyKilled();
        }
    }

    void EnemyKilled()
    {
        alive = false;
    }
}
