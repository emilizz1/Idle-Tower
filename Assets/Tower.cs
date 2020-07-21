using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float range;

    [SerializeField] float damage, fireRate;

    Enemy target;
    float timeToNextShot;
    
    void Start()
    {
        
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
        }
    }

    IEnumerator Shooting()
    {
        while (target)
        {
            yield return null;
            if(timeToNextShot <= 0)
            {
                timeToNextShot = fireRate;
                
            }
        }
    }
}
