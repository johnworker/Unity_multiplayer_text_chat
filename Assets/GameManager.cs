using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int maxMessages = 25;

    public GameObject chatPanel, textObject;
    public InputField chatBox;

    [SerializeField]
    List<Message> messageList = new List<Message>();
    void Start()
    {
        
    }

    void Update()
    {
        if(chatBox.text != "")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SendManagerToChat(chatBox.text);
                chatBox.text = "";
            }
        }

        if (!chatBox.isFocused)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                SendManagerToChat("You pressed the space key!");
            Debug.Log("Space");
        }

    }

    public void SendManagerToChat(string text) 
    {
        if (messageList.Count >= maxMessages)
        {
            Destroy(messageList[0].textObject.gameObject);
            messageList.Remove(messageList[0]);
        }

        Message newMassage = new Message();

        newMassage.text = text;

        GameObject newText = Instantiate(textObject, chatPanel.transform);

        newMassage.textObject = newText.GetComponent<Text>();

        newMassage.textObject.text = newMassage.text;

        messageList.Add(newMassage);
    }
}

[System.Serializable]
public class Message
{
    public string text;
    public Text textObject;
}
