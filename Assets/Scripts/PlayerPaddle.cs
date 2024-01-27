using UnityEngine;

public class PlayerPaddle : Paddle
{
    private Vector2 direction;
    public FixedJoystick fixedJoystick;
    
    private void Update()
    {
        // Initialize direction to zero every frame
        direction = Vector2.zero;

        // Read joystick values
        float horizontal = fixedJoystick.Horizontal;
        float vertical = fixedJoystick.Vertical;

        // Check if joystick is being moved
        if (Mathf.Abs(horizontal) > 0.1f || Mathf.Abs(vertical) > 0.1f) 
        {
            // Joystick is being moved; use its values
            direction = new Vector2(horizontal, vertical);
        }
        else
        {
            // Joystick is not being moved; use keyboard controls
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                direction = Vector2.up;
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                direction = Vector2.down;
            }
            
        }
    }

    private void FixedUpdate()
    {
        if (direction.sqrMagnitude != 0) {
            rb.AddForce(direction * speed);
        }
    }

}
