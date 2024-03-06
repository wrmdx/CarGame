using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGen : MonoBehaviour
{
    public GameObject roadPrefab; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MyCar")) 
        {
            InstantiateRoad();
        }
    }

    void InstantiateRoad()
    {
        Instantiate(roadPrefab, transform.position, Quaternion.identity);
    }
}
