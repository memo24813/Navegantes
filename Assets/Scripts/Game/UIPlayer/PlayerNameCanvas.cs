using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameCanvas : MonoBehaviour
{
    public Text playerName;
    PhotonView _pv;
    void Start()
    {
        _pv = GetComponent<PhotonView>();
        if(_pv.IsMine)
        {
            playerName.text = PhotonNetwork.NickName;
        }
        else
        {
            
            foreach (Player item in PhotonNetwork.PlayerList)
            {
                if(_pv.Owner.NickName.Equals(item.NickName))
                {
                    playerName.text = item.NickName;
                }
            }
            
            
        }
    }
}
