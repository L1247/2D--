#region

using TMPro;
using UnityEngine;

#endregion

namespace UI
{
    public class TypewriterEffect : MonoBehaviour
    {
    #region Public Variables

        public string text;

    #endregion

    #region Private Variables

        private float time;

        private int wordIndex;

        [SerializeField]
        private TMP_Text dialog;

        [SerializeField]
        private float everyCharacterDelay = 0.3f;

    #endregion

    #region Unity events

        private void Awake()
        {
            dialog.text = "";
            wordIndex   = 0;
        }

        private void Update()
        {
            if (wordIndex == text.Length) return;
            time += Time.deltaTime;
            if (time >= everyCharacterDelay)
            {
                dialog.text += text[wordIndex].ToString();
                wordIndex   += 1;
                time        =  0;
            }
        }

    #endregion
    }
}