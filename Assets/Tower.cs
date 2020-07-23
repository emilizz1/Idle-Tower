using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float range;

    [SerializeField] GameObject bullet;
    [SerializeField] float fireRate;

    Enemy target;
    float timeToNextShot;
    
    void Start()
    {
        StartCoroutine(LookingForTarget());
    }

    void Update()
    {
        if (timeToNextShot > 0)
        {
            timeToNextShot -= Time.deltaTime;
        }
    }

    IEnumerator LookingForTarget()
    {
        while (target== null)
        {
            yield return null;
            target = EnemySpawner.instance.GetTarget(this);
        }
        StartCoroutine(Shooting());
    }

    IEnumerator Shooting()
    {
        while (target)
        {
            if (Vector2.Distance(transform.position, target.transform.position) > range)
            {
                target = null;
            }
            if (timeToNextShot <= 0)
            {
                GameObject createdBullet = Instantiate(bullet, transform.position, Quaternion.identity, null);
                createdBullet.GetComponent<Bullet>().target = target;
                timeToNextShot = fireRate;
            }
            yield return null;
        }
        StartCoroutine(LookingForTarget());        
    }
}
