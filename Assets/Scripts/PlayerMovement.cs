#region

using UnityEngine;

#endregion

public class PlayerMovement : MonoBehaviour
{
#region Public Variables

    public float jumpY;

    public int moveSpeed;

    public Rigidbody2D rigidbody2D;

#endregion

#region Unity events

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var movementX  = horizontal * moveSpeed;
        // print(movementX);
        var newVelocity = new Vector2(movementX , rigidbody2D.velocity.y);
        rigidbody2D.velocity = newVelocity;

        var jumpKeyDown = Input.GetKeyDown(KeyCode.Space);
        if (jumpKeyDown)
        {
            print("空白鍵按下");
            var y = 100 * jumpY;

            var jumpForce = new Vector2(0 , y);
            rigidbody2D.AddForce(jumpForce);
        }
    }

#endregion
}