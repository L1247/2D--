#region

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

#endregion

public class Dialog : MonoBehaviour
{
#region Public Variables

    public bool effectTyping; // 正在執行效果

    public float letterWaitTime = 0.1f; // 每個字等待的時間

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
        // dialogText.text =  sentences[sentenceIndex];
        gameObject.SetActive(false); // 關閉物件顯示
    }

    // Update is called once per frame
    private void Update()
    {
        // index:3 , count: 3 
        // 所有句子播放完畢後，不繼續執行
        if (sentenceIndex >= sentences.Count) return;

        if (effectTyping) return; // 如果效果執行中，就不執行

        // 左鍵按下
        if (Input.GetMouseButtonDown(0) /*&& effectTyping == false*/)
        {
            // dialogText.text =  sentences[sentenceIndex];
            // 句子
            var line = sentences[sentenceIndex];
            // 協程
            StartCoroutine(DoTypeWriteEffect(line));
            sentenceIndex += 1; // index + 1
        }
    }

#endregion

#region Public Methods

    [ContextMenu("ShowSentences")]
    public void ShowSentences()
    {
        // 句子
        var line = sentences[sentenceIndex];
        // 協程
        StartCoroutine(DoTypeWriteEffect(line));
        sentenceIndex += 1; // index + 1
    }

#endregion

#region Private Methods

    /// <summary>
    ///     執行打字機效果
    /// </summary>
    /// <param name="line"></param>
    /// <returns></returns>
    private IEnumerator DoTypeWriteEffect(string line)
    {
        effectTyping = true;
        // 清空文字框
        dialogText.text = "";
        foreach (var c in line)
        {
            var letter = c.ToString();
            print(letter);
            dialogText.text += letter;
            // 延遲0.1秒執行一次
            yield return new WaitForSeconds(letterWaitTime);
        }

        // 執行完畢
        effectTyping = false;
    }

#endregion
}