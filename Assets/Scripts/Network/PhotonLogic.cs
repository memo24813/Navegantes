using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonLogic : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }


    public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinOrCreateRoom("Cuarto",new RoomOptions{MaxPlayers = 10}, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.NickName = "memo";
        PhotonNetwork.Instantiate("Jugador", new Vector3(Random.Range(-10,10),0,0), Quaternion.identity);
    }
}
