using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
using Photon.Pun;
using TMPro;
public class CreateRoomMenu : MonoBehaviourPunCallbacks
{

    [SerializeField]
    private TextMeshProUGUI _roomName;
    [SerializeField]
    private TextMeshProUGUI _titleroomName;

    private RoomsCanvases _roomsCanvas;
    public void FirstInitialize(RoomsCanvases canvas)
    {
        _roomsCanvas = canvas;
    }
    public void OnClick_CreateRoom()
    {
        if(!PhotonNetwork.IsConnected)
            return;
            
        RoomOptions options = new RoomOptions();
        options.BroadcastPropsChangeToAll = true;
        options.MaxPlayers = 8;
        _titleroomName.text = _roomName.text;
        PhotonNetwork.JoinOrCreateRoom(_roomName.text,options, TypedLobby.Default);
    }


    public override void OnCreatedRoom()
    {
        Debug.Log("Se creo la sala correctamente");
        _roomsCanvas.CreateOrJoinRoomCanvas.Hide(); //yo agregue
        _roomsCanvas.CurrentRoomCanvas.Show();
    }

    public override void OnCreateRoomFailed(short returnCode,string message)
    {
        Debug.Log("Fallo al crear la sala"+message);
    }
}
