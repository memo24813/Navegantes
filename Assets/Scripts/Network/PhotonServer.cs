using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonServer : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Conectado con el servidor.");
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.NickName = MasterManager.GameSettings.NickName;
        PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Conectado al servidor");
        Debug.Log(PhotonNetwork.LocalPlayer.NickName);
        PhotonNetwork.JoinLobby();
    }

    public override void OnDisconnected (DisconnectCause cause)
    {
        Debug.Log("Desconectado del servidor, razon: "+cause.ToString());
    }
}
