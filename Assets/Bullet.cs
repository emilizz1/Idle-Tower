using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed, damage;

    internal Enemy target;

    private void Update()
    {
        if (target)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            if(Vector2.Distance(transform.position, target.transform.position) < 0.1f)
            {
                target.DealDamage(damage);
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
