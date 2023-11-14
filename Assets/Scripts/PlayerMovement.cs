#region

using UnityEngine;

#endregion

public class PlayerMovement : MonoBehaviour
{
#region Public Variables

    public Rigidbody2D rigidbody2D;

#endregion

#region Unity events

    // Update is called once per frame
    void Update()
    {
        rigidbody2D.velocity = new Vector2(1 , rigidbody2D.velocity.y);
    }

#endregion
}