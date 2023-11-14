using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
#region Public Variables

    public Rigidbody2D rigidbody2D;

#endregion

#region Unity events

    // Update is called once per frame
    void Update()
    {
        rigidbody2D.velocity = new Vector2(1 , 0);
    }

#endregion
}