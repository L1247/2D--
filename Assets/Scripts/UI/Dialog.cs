#region

using System.Collections.Generic;
using TMPro;
using UnityEngine;

#endregion

public class Dialog : MonoBehaviour
{
#region Public Variables

    public List<string> sentences;

    public TMP_Text dialogText;

#endregion

#region Unity events

    // Start is called before the first frame update
    private void Start()
    {
        dialogText.text = sentences[0];
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) dialogText.text = "新句子";
    }

#endregion
}