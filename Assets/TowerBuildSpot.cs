using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class TowerBuildSpot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject tower;

    Vector3 offset = new Vector3(0f, 0f, 0.001f);

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        Instantiate(tower, transform.position + offset, Quaternion.identity, transform);
    }
}
