#region

using TMPro;
using UnityEngine;

#endregion

public class Dialog : MonoBehaviour
{
#region Public Variables

    public TMP_Text dialogText;

#endregion

#region Unity events

    // Start is called before the first frame update
    private void Start()
    {
        dialogText.text = "中文測試";
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) dialogText.text = "新句子";
    }

#endregion
}