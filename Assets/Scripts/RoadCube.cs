using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadCube : MonoBehaviour
{
    public GameObject road;
    public GameObject obstacle;
    public GameObject coin;

    private bool hasInstantiated = false;  // Flag to track instantiation

    void Start()
    {
        // Initialization code (if needed)
    }

    void Update()
    {
        // Update code (if needed)
    }

    void OnTriggerEnter(Collider collider)
    {
        // Check if instantiation has already occurred
        if (!hasInstantiated)
        {
            // Set the flag to true to prevent further instantiations
            hasInstantiated = true;

            // Instantiate a new road prefab at a specific position (z + 7 units from the collider's position)
            Instantiate(road, new Vector3(road.transform.position.x, road.transform.position.y, transform.position.z + 10), Quaternion.identity);

            // Instantiate an obstacle prefab at a random position on the x-axis and the same z position as the collider (z + 7 units)
            Vector3 position1 = new Vector3(Random.Range(0, 4), 0f, collider.gameObject.transform.position.z + 7);
            Instantiate(obstacle, position1, Quaternion.identity);

            // Instantiate a coin prefab at a random position on the x-axis and the same z position as the collider (z + 7 units)
            Vector3 position = new Vector3(Random.Range(0, 4), 0.5f, collider.gameObject.transform.position.z + 7);
            Instantiate(coin, position, Quaternion.identity);
        }
    }
}
