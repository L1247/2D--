#region

using UnityEngine;
using UnityEngine.UI;

#endregion

namespace Input_UI.Scripts
{
    public class InputUI : MonoBehaviour
    {
    #region Public Variables

        public Image left;

        public Image right;

        public Image space;

    #endregion

    #region Private Variables

        private readonly Color keyDownColor = Color.white;
        private readonly Color keyUpColor   = new Color(Color.gray.r , Color.gray.g , Color.gray.b , 0.5f);

    #endregion

    #region Unity events

        public void Update()
        {
            left.color  = Input.GetAxisRaw("Horizontal") < 0 ? keyDownColor : keyUpColor;
            right.color = Input.GetAxisRaw("Horizontal") > 0 ? keyDownColor : keyUpColor;
            space.color = Input.GetKey(KeyCode.Space) ? keyDownColor : keyUpColor;
        }

    #endregion
    }
}