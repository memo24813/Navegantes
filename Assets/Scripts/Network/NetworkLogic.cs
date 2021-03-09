using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// network
using Photon.Pun;
using Photon.Realtime;
public class NetworkLogic : MonoBehaviourPunCallbacks
{

    public static NetworkLogic instance;
    private void Awake() {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Conexion exitosa.");
        if(!PhotonNetwork.InLobby)
            PhotonNetwork.JoinLobby();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Error al conectar to Photon"+cause.ToString());
    }


    public override void OnJoinedLobby()
    {
        Debug.Log("Conectado al lobby.");
    }
}
