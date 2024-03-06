using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float moveSpeed = 5f ; 
    public float rotationSpeed=100f  ; 
    // Start is called before the first frame update
    void Start()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
                MoveCar(verticalInput);

        // Rotate the car left/right
        RotateCar(horizontalInput);
    }
    private void MoveCar(float input)
    {
        Vector3 moveDirection = transform.forward * input * moveSpeed * Time.deltaTime;
        transform.Translate(moveDirection, Space.World);
    }

    private void RotateCar(float input)
    {
        float rotation = input * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotation);
    }
}
