using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class PlayerPropertiesGame : MonoBehaviour
{
    public int misionsMax = 10;
    public int misionsStart = 0;
    public bool isAlive = true;
    public bool isNavigator = true;



    // public void SetPropertiesPlayers()
    // {
    //     int impostorNumber = Random.Range(0,PhotonNetwork.PlayerList.Length - 1);

    //     for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
    //     {
    //         _myCustomProperties["misionsMax"] =misionsMax;
    //         _myCustomProperties["misionsStart"] = misionsMax;
    //         _myCustomProperties["isAlive"] = isAlive;
    //         _myCustomProperties["isNavigator"] = isNavigator;

    //         if(impostorNumber==i)
    //             _myCustomProperties["isNavigator"] = false;
    //             // _myCustomProperties.Add("isNavigator",false);

    //         PhotonNetwork.PlayerList[i].SetCustomProperties(_myCustomProperties);
    //     }
    // }

    public void SetImpostorPlayer()
    {
        ExitGames.Client.Photon.Hashtable _myCustomProperties = new ExitGames.Client.Photon.Hashtable();
        _myCustomProperties.Add("misionsMax",misionsMax);
        _myCustomProperties.Add("misionsStart",misionsStart);
        _myCustomProperties.Add("isAlive",isAlive);
        _myCustomProperties.Add("isNavigator",false);

        int impostorNumber = Random.Range(0,PhotonNetwork.PlayerList.Length);
        PhotonNetwork.PlayerList[impostorNumber].SetCustomProperties(_myCustomProperties);
        // if(impostorNumber == 0 )
    }

    public void SetPlayerProperties()
    {
        ExitGames.Client.Photon.Hashtable _myCustomProperties = new ExitGames.Client.Photon.Hashtable();
        _myCustomProperties.Add("misionsMax",misionsMax);
        _myCustomProperties.Add("misionsStart",misionsStart);
        _myCustomProperties.Add("isAlive",isAlive);
        _myCustomProperties.Add("isNavigator",isNavigator);
        PhotonNetwork.LocalPlayer.SetCustomProperties(_myCustomProperties);
    }
}
