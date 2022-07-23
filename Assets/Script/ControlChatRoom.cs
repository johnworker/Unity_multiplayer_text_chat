
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControlChatRoom : MonoBehaviour
{

    public InputField chatInput;
    public TextMeshProUGUI chatText;
    public ScrollRect scrollRect;
    string username = "DHX";
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (chatInput.text != "")
            {
                string addText = "\n  " + "<color=red>" + username + "</color>:\u00A0" + chatInput.text;
                chatText.text += addText;
                chatInput.text = "";
                chatInput.ActivateInputField();
                Canvas.ForceUpdateCanvases();
                scrollRect.verticalNormalizedPosition = 0f;
                Canvas.ForceUpdateCanvases();
            }
        }

    }
}