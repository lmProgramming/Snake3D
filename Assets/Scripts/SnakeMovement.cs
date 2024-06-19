using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    [SerializeField]
    private Snake snake;

    public float pitchPower, rollPower, yawPower, movementSpeed;

    private float activeRoll, activePitch, activeYaw;


    private void FixedUpdate()
    {
        if (snake.alive)
        {
            float speedMultiplier = 1;
            if (Input.GetKey(KeyCode.Space))
            {
                speedMultiplier = 4;
            }

            // move forward
            transform.position += transform.forward * movementSpeed * speedMultiplier * Time.deltaTime;

            activePitch = Input.GetAxisRaw("Vertical") * pitchPower * Time.deltaTime;
            activeRoll = Input.GetAxisRaw("Rotational") * rollPower * Time.deltaTime;
            activeYaw = Input.GetAxisRaw("Horizontal") * yawPower * Time.deltaTime;

            transform.Rotate(activePitch * pitchPower * Time.deltaTime,
                activeYaw * yawPower * Time.deltaTime,
                -activeRoll * rollPower * Time.deltaTime,
                Space.Self);
        }
    }
}
