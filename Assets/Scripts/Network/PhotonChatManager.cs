using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Chat;
using ExitGames.Client.Photon;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;
public class PhotonChatManager : MonoBehaviour, IChatClientListener
{
    ChatClient chatClient;
    // [SerializeField] Text userID;

    // public GameObject PanelLogin;
    public GameObject PanelRoom;
    public string worldChat;

    public TMP_InputField messageInput;
    public Text messageArea;
    void Start()
    {
        // chatClient = new ChatClient(this);
        // chatClient.Connect(PhotonNetwork.PhotonServerSettings.AppSettings.AppIdChat,PhotonNetwork.AppVersion, new AuthenticationValues(userID.text));
        GetConnect();
    }
    //Users
    public void GetConnect()
    {
        // if(userID.text!="")
        // {
        // PlayersStatus name = GameObject.Find("Users").GetComponent<PlayersStatus>();
        // PhotonNetwork.NickName = userID.text;
        worldChat = PhotonNetwork.CurrentRoom.Name;
        chatClient = new ChatClient(this);
        chatClient.Connect(PhotonNetwork.PhotonServerSettings.AppSettings.AppIdChat,PhotonNetwork.AppVersion, new AuthenticationValues(PhotonNetwork.NickName));
        // PanelLogin.SetActive(false);
        PanelRoom.SetActive(true);
        // OnConnected();
        // }
    }

    // Update is called once per frame
    void Update()
    {
        if(chatClient!=null)
            chatClient.Service();

        if(Input.GetKeyDown(KeyCode.Return))
        {
            if(messageInput.text.Length>0)
            {
                sendMsg();
                messageInput.Select();
                messageInput.ActivateInputField();
            }
        }
    }


    public void sendMsg()
    {
        chatClient.PublishMessage(worldChat,messageInput.text);
        messageInput.text = "";
    }
    public void DebugReturn(DebugLevel level,string message)
    {

    }
    public void OnChatStateChange(ChatState state)
    {

    }

    public void OnConnected()
    {
        chatClient.Subscribe(new string[] {worldChat});
        chatClient.SetOnlineStatus(ChatUserStatus.Online);
        chatClient.PublishMessage(worldChat," se ha unido.");

    }

    public void OnDisconnected()
    {
        chatClient.PublishMessage(worldChat," ha abandonado la partida.");
    }

    public void OnGetMessages(string channelName, string[] senders, object[] messages)
    {
        for (int i = 0; i < senders.Length; i++)
        {
           messageArea.text+= senders[i] + ": " + messages[i]+"\n";  
        }
    }

    public void OnPrivateMessage(string sender, object message, string channelName)
    {

    }

    public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {

    }

    public void OnSubscribed(string[] channels, bool[] results)
    {

    }

    public void OnUnsubscribed(string[] channels)
    {

    }

    public void OnUserSubscribed(string channel, string user)
    {

    }

    public void OnUserUnsubscribed(string channel,string user)
    {

    }


}
