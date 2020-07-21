using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathController : MonoBehaviour
{
    public static PathController instance;

    public List<Vector3> path;

    private void Awake()
    {
        instance = this;
    }
}
