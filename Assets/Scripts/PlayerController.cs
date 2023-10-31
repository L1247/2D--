#region

using UnityEngine;

#endregion

public class PlayerController : MonoBehaviour
{
#region Unity events

    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
    private void Update()
    {
        Debug.Log("Update");
        var direction = new Vector3(1 , 0 , 0);
        var moveSpeed = 5;
        var fps       = Time.deltaTime;
        var movement  = direction * fps * moveSpeed;
        transform.position += movement;
    }

#endregion
}