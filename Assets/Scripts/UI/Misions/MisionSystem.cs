using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MisionSystem : MonoBehaviour
{
    private int _misionsComplete;
    public int misionsComplete{get{
        _misionsComplete = 0;
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            _misionsComplete+= (int) player.CustomProperties["misionsStart"];
        }
        return _misionsComplete;}}
    private int _maxMisions;
    public int maxMisions{get{
        _maxMisions = (PhotonNetwork.PlayerList.Length - 1) * (int)PhotonNetwork.PlayerList[0].CustomProperties["misionsMax"];
        if(_maxMisions==0)
        {
            _maxMisions = 10;
        }
        return _maxMisions;}}

    private void Start() {
        _misionsComplete = misionsComplete;
        _maxMisions = maxMisions;
    }
    public bool PlayerMisionsComplete()
    {
        return (misionsComplete == maxMisions);
    }

    private void Update() {
        if(PlayerMisionsComplete())
        {
            // PhotonNetwork.LoadLevel(2);
            PhotonNetwork.LeaveLobby();
            SceneManager.LoadScene(2);
        }
        if(PlayerMisionsFailture())
        {
            // PhotonNetwork.LoadLevel(3);
            // PhotonNetwork.LeaveRoom(true);
            PhotonNetwork.LeaveLobby();
            SceneManager.LoadScene(3);
        }
    }
    public bool PlayerMisionsFailture()
    {
        int countPlayerDie = 0;

        foreach (Player player in PhotonNetwork.PlayerList)
        {
            if((bool)player.CustomProperties["isAlive"] == false)
                countPlayerDie++;
        }

        return (countPlayerDie == (PhotonNetwork.PlayerList.Length-1));
    }

    
}
