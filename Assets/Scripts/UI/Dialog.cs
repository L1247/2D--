#region

using System.Collections.Generic;
using TMPro;
using UnityEngine;

#endregion

public class Dialog : MonoBehaviour
{
#region Public Variables

    /// <summary>
    ///     句子的索引，紀錄目前在陣列第幾個元素
    /// </summary>
    public int sentenceIndex;

    public List<string> sentences;

    public TMP_Text dialogText;

#endregion

#region Unity events

    // Start is called before the first frame update
    private void Start()
    {
        // 設定文字為陣列第一句
        dialogText.text =  sentences[sentenceIndex];
        sentenceIndex   += 1; // index + 1
    }

    // Update is called once per frame
    private void Update()
    {
        // 左鍵按下
        if (Input.GetMouseButtonDown(0))
        {
            dialogText.text =  sentences[sentenceIndex];
            sentenceIndex   += 1; // index + 1
        }
    }

#endregion
}