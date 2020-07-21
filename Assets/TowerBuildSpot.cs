using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class TowerBuildSpot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject tower;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        Instantiate(tower, transform.position, Quaternion.identity, transform);
    }
}
