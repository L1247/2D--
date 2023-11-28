#region

using UnityEngine;

#endregion

public class PowerUpDoubleJump : MonoBehaviour
{
#region Private Methods

    private void OnTriggerEnter2D(Collider2D col)
    {
        print(col.gameObject.name + "碰到我.");
        var isPlayerCharacter = col.gameObject.name == "PlayerCharacter";
        // 如果碰到玩家角色，讓玩家角色開啟兩段跳
        if (isPlayerCharacter)
        {
            var playerJump = col.GetComponent<PlayerJump>();
            playerJump.EnableDoubleJump();
            // 關閉我自己
            gameObject.SetActive(false);
        }
    }

#endregion
}