using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int maxMessages = 25;

    [SerializeField]
    List<Message> messageList = new List<Message>();
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SendManagerToChat("You pressed the space key!");
    }

    public void SendManagerToChat(string text) 
    {
        if (messageList.Count >= maxMessages)
            messageList.Remove(messageList[0]);

        Message newMassage = new Message();

        newMassage.text = text;

        messageList.Add(newMassage);
    }
}

[System.Serializable]
public class Message
{
    public string text;
}
