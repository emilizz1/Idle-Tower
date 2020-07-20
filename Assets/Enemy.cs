using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health, speed;

    bool alive;

    void Start()
    {
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        int pahtStep = 0;
        Vector3 currentTarget = PathController.instance.paht[pahtStep];
        while (alive)
        {
            yield return null;
            Vector2.MoveTowards(transform.position, currentTarget, speed);
            if(Vector2.Distance(currentTarget, transform.position) < 0.01f)
            {
                pahtStep++;
                currentTarget = PathController.instance.paht[pahtStep];
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
