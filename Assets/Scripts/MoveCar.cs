using System.Collections;
using UnityEngine;

public class MoveCar : MonoBehaviour
{
    public float moveSpeed = 9f; 
    public float normalMoveSpeed = 9f;  // Original move speed
    public float rotationSpeed = 100f;
    public GameObject camera;
    public int score = 0; 

    public float driftFactor = 0.9f; // Adjust this value for the drift effect
    public float obstacleSlowdownDuration = 1.5f;

    private bool isSlowedDown = false;  // Flag to check if car speed is slowed down

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // If the car is slowed down, reduce the move speed temporarily
        if (isSlowedDown)
        {
            StartCoroutine(SlowDownEffect());
        }

        MoveCarForward(verticalInput);
        RotateCar(horizontalInput);
        Vector3 position = new Vector3(0, 0, verticalInput);
        camera.transform.Translate(position * moveSpeed * Time.deltaTime);

        // Check if the car is rotating and apply drift
        if (Mathf.Abs(horizontalInput) > 0.1f)
        {
            ApplyDrift();
        }
    }

    IEnumerator SlowDownEffect()
    {
        // Slow down the car for the specified duration
        moveSpeed = normalMoveSpeed / 2f;  // You can adjust the factor for slowdown
        yield return new WaitForSeconds(obstacleSlowdownDuration);
        moveSpeed = normalMoveSpeed;  // Return to normal speed
        isSlowedDown = false;
    }

    private void MoveCarForward(float input)
    {
        Vector3 moveDirection = transform.forward * input * moveSpeed * Time.deltaTime;
        transform.Translate(moveDirection, Space.World);
    }

    private void RotateCar(float input)
    {
        float rotation = input * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotation);
    }

    private void ApplyDrift()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity *= driftFactor;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "coin")
        { 
            Debug.Log("Score " + score);
            Destroy(collision.gameObject);
            score++;
        }

        if (collision.gameObject.tag == "obstacle")
        {
            // Slow down the car when it collides with an obstacle
            isSlowedDown = true;
        }
    }
}
