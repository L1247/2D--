#region

using System.Collections;
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

        private bool showing;

        private bool isDialogPlaying;

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
            Reset();
            // ShowDialog();
        }

        private void Update()
        {
            if (isDialogPlaying) return;

            if (Input.GetMouseButtonDown(0) && showing)
            {
                if (sentenceIndex == sentences.Count)
                {
                    Reset();
                    return;
                }

                DisplayNextLine();
            }
        }

    #endregion

    #region Private Methods

        private IEnumerator DisplayLine(string line)
        {
            var isAddingRichTextTag = false;
            isDialogPlaying = true;
            foreach (var c in line)
            {
                var letter = c.ToString();
                if (letter == "<" || isAddingRichTextTag)
                {
                    isAddingRichTextTag =  true;
                    dialog.text         += letter;
                    if (letter == ">") isAddingRichTextTag = false;
                }
                else
                {
                    dialog.text += letter;
                    yield return new WaitForSeconds(everyCharacterDelay);
                }
            }

            isDialogPlaying = false;
        }

        private void DisplayNextLine()
        {
            dialog.text = "";
            var line = sentences[sentenceIndex];
            sentenceIndex++;
            StartCoroutine(DisplayLine(line));
        }

        [ContextMenu("Reset")]
        private void Reset()
        {
            isDialogPlaying = false;
            dialog.text     = "";
            showing         = false;
            wordIndex       = 0;
            sentenceIndex   = 0;
            continueImage.gameObject.SetActive(false);
            bgImage.gameObject.SetActive(false);
        }

        [ContextMenu("ShowDialog")]
        private void ShowDialog()
        {
            showing = true;
            bgImage.gameObject.SetActive(true);
            dialog.text = "";
            DisplayNextLine();
        }

    #endregion
    }
}