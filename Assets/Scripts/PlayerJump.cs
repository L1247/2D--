#region

using UnityEngine;

#endregion

public class PlayerJump : MonoBehaviour
{
#region Public Variables

    public float jumpY;

    /// <summary>
    ///     目前跳躍次數
    /// </summary>
    public int jumpCount;

    /// <summary>
    ///     最大跳躍次數
    /// </summary>
    public int maxJumpCount = 1;

    public Rigidbody2D rigidbody2D;

#endregion

#region Unity events

    // Update is called once per frame
    private void Update()
    {
        var jumpKeyDown = Input.GetKeyDown(KeyCode.Space);
        //  可以跳躍 = 目前跳躍次數 小於 最大跳躍次數
        var canJump = jumpCount < maxJumpCount;
        if (jumpKeyDown && canJump)
        {
            print("空白鍵按下");
            // 跳躍次數 +1
            jumpCount = jumpCount + 1;
            // jumpCount += 1;
            // jumpCount ++;

            // reset velocity's y
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x , 0);

            // add jump force
            var y         = 100 * jumpY;
            var jumpForce = new Vector2(0 , y);
            rigidbody2D.AddForce(jumpForce);
        }
    }

#endregion

#region Private Methods

    private void OnCollisionEnter2D(Collision2D col)
    {
        print(col.gameObject);

        // 如果角色碰到地板，重製跳躍次數
        var isFloor            = col.gameObject.name == "Floor";
        if (isFloor) jumpCount = 0;
    }

#endregion
}