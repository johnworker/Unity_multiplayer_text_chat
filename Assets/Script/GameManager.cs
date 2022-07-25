using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("�ϥΪ̦W��")]
    [Tooltip("�п�J�ϥΪ̦W��")]
    public string username;

    [Header("�T���̤j�W���i�ΩԱ�վ�"),Range(15,25)]
    [Tooltip("�����O�����ӻݨD���w�]�A�ثe�L�\��K�[")]
    public int maxMessages = 25;

    public GameObject chatPanel, textObject;
    [Header("��r��J�����")]
    public TMP_InputField chatBox;

    public Color playerMessage, info;

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
                SendManagerToChat(username + ": " + chatBox.text, Message.MessageType.playerMessage);
                chatBox.text = "";
            }
        }

        else
        {
            if (!chatBox.isFocused && Input.GetKeyDown(KeyCode.Return))
                chatBox.ActivateInputField();
        }

        if (!chatBox.isFocused)
        {
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
                SendManagerToChat("You pressed the space bar!", Message.MessageType.info);
            Debug.Log("Enter to send your message");
        }

    }

    public void SendManagerToChat(string text, Message.MessageType messageType) 
    {
        
        Message newMassage = new Message();

        newMassage.text = text;

        GameObject newText = Instantiate(textObject, chatPanel.transform);

        newMassage.textObject = newText.GetComponent<TextMeshProUGUI>();

        newMassage.textObject.text = newMassage.text;
        newMassage.textObject.color = MessageTypeColor(messageType);

        messageList.Add(newMassage);
    }

    Color MessageTypeColor(Message.MessageType messageType)
    {
        Color color = info;

        switch (messageType)
        {
            case Message.MessageType.playerMessage:
                color = playerMessage;
                break;


        }

        return color;
    }
}

[System.Serializable]
public class Message
{
    public string text;
    public TextMeshProUGUI textObject;
    public MessageType messageType;

    public enum MessageType
    {
        playerMessage,
        info
    }
}
