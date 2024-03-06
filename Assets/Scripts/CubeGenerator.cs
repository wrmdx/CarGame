using UnityEngine;

public class CuubeGenerator : MonoBehaviour
{
    public GameObject redCubePrefab;
    public GameObject whiteCubePrefab;
    public int numberOfCubes = 10; // Change this value as per your requirement
    public float cubeSpacing = 1.0f; // Adjust this value for the space between cubes

    void Start()
    {
        DuplicateCubes();
    }

    void DuplicateCubes()
    {
        Vector3 startPosition = transform.position;

        for (int i = 0; i < numberOfCubes; i++)
        {
            // Check if the index is even or odd to determine the cube color
            GameObject cubePrefab = i % 2 == 0 ? redCubePrefab : whiteCubePrefab;

            // Instantiate cube on the positive side of z-axis
            GameObject cubePositive = Instantiate(cubePrefab, startPosition + new Vector3(0f, 0f, i * cubeSpacing), Quaternion.identity);
            cubePositive.transform.parent = transform;

            // Instantiate cube on the negative side of z-axis
            GameObject cubeNegative = Instantiate(cubePrefab, startPosition + new Vector3(0f, 0f, -i * cubeSpacing), Quaternion.identity);
            cubeNegative.transform.parent = transform;
        }
    }

    void Update()
    {
        // Example: Print the position of the generator object
        //Debug.Log("Generator Position: " + transform.position);
    }
}
