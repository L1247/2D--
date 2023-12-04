#region

using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

#endregion

namespace UI
{
    public class TypewriterEffect : MonoBehaviour
    {
    #region Public Variables

        public List<string> sentences;

    #endregion

    #region Private Variables

        private float time;

        private int wordIndex;
        private int sentenceIndex;

        [SerializeField]
        private TMP_Text dialog;

        [SerializeField]
        private float everyCharacterDelay = 0.3f;

        [SerializeField]
        private Image continueImage;

        [SerializeField]
        private Image bgImage;

    #endregion

    #region Unity events

        private void Awake()
        {
            dialog.text   = "";
            wordIndex     = 0;
            sentenceIndex = 0;
            continueImage.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                sentenceIndex += 1;
                dialog.text   =  "";
                wordIndex     =  0;
                time          =  0;
                continueImage.gameObject.SetActive(false);
            }

            if (sentenceIndex >= sentences.Count)
            {
                bgImage.gameObject.SetActive(false);
                return;
            }

            var sentence = sentences[sentenceIndex];
            if (wordIndex == sentence.Length)
            {
                continueImage.gameObject.SetActive(true);
                return;
            }

            time += Time.deltaTime;
            if (time >= everyCharacterDelay)
            {
                var letter = sentence[wordIndex];
                dialog.text += letter;
                wordIndex   += 1;
                time        =  0;
            }
        }

    #endregion

    #region Private Methods

        [ContextMenu("Reset")]
        private void Reset()
        {
            dialog.text   = "";
            wordIndex     = 0;
            sentenceIndex = 0;
            continueImage.gameObject.SetActive(false);
            bgImage.gameObject.SetActive(true);
        }

    #endregion
    }
}