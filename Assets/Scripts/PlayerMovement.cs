#region

using UnityEngine;

#endregion

public class PlayerMovement : MonoBehaviour
{
#region Public Variables

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
    }

#endregion
}