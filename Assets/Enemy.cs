using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float maxHealth, speed;
    [SerializeField] SpriteMask healthBar;
    [SerializeField] float zeroHealthPos;

    bool alive = true;
    float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
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
                if(pahtStep == PathController.instance.path.Count)
                {
                    EnemyKilled();
                    break;
                }
                currentTarget = PathController.instance.path[pahtStep];
            }
        }
    }

    public void DealDamage(float _damage)
    {
        currentHealth -= _damage;
        healthBar.transform.localPosition = new Vector2(0f, (1 - (currentHealth / maxHealth)) * zeroHealthPos);
        if(currentHealth <= 0)
        {
            EnemyKilled();
        }
    }

    void EnemyKilled()
    {
        alive = false;
        EnemySpawner.instance.enemies.Remove(this);
        Destroy(gameObject);
    }
}
