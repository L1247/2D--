#region

using UnityEngine;

#endregion

public class PlayerJump : MonoBehaviour
{
#region Public Variables

    /// <summary>
    ///     跳躍力道
    /// </summary>
    public float jumpPower;

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

            // reset velocity's y , 避免被落下的重力影響，每次跳躍前先重設Y軸力道
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x , 0);

            // add jump force，對物理元件施一個往上的力道
            var forceY    = 100 * jumpPower;
            var jumpForce = new Vector2(0 , forceY);
            rigidbody2D.AddForce(jumpForce);
        }
    }

#endregion

#region Public Methods

    /// <summary>
    ///     開啟兩段跳
    /// </summary>
    [ContextMenu("EnableDoubleJump")]
    public void EnableDoubleJump()
    {
        maxJumpCount = 2;
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