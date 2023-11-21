#region

using UnityEngine;

#endregion

public class PlayerJump : MonoBehaviour
{
#region Public Variables

    public float jumpY;

    public Rigidbody2D rigidbody2D;

#endregion

#region Unity events

    // Update is called once per frame
    private void Update()
    {
        var jumpKeyDown = Input.GetKeyDown(KeyCode.Space);
        if (jumpKeyDown)
        {
            print("空白鍵按下");
            // reset velocity's y
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x , 0);
            var y         = 100 * jumpY;
            var jumpForce = new Vector2(0 , y);
            rigidbody2D.AddForce(jumpForce);
        }
    }

#endregion
}