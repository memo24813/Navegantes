using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerDescription : MonoBehaviour
{
    public string nameNavigator;
    public string NameNavigator{get{return nameNavigator;}}
    public int misionsMax ;
    public int MisionsMax{get{return (int)PhotonNetwork.LocalPlayer.CustomProperties["misionsMax"];}}
    public int misionsCount;
    public int MisionsCount{get{return (int) PhotonNetwork.LocalPlayer.CustomProperties["misionsStart"];}}
    public bool isNavigator ;
    public bool IsNavigator{get{return (bool) PhotonNetwork.LocalPlayer.CustomProperties["isNavigator"];}}
    public bool isAlive ;
    public bool IsAlive{get{return (bool)PhotonNetwork.LocalPlayer.CustomProperties["isAlive"];}}

    void Awake()
    {
        nameNavigator = PhotonNetwork.LocalPlayer.NickName;
        misionsMax = (int)PhotonNetwork.LocalPlayer.CustomProperties["misionsMax"];
        misionsCount = (int) PhotonNetwork.LocalPlayer.CustomProperties["misionsStart"];
        isAlive = (bool) PhotonNetwork.LocalPlayer.CustomProperties["isAlive"];
        isNavigator = (bool) PhotonNetwork.LocalPlayer.CustomProperties["isNavigator"];
        printToString();
    }


    public void printToString()
    {
        Debug.Log(nameNavigator+":"+MisionsMax+":"+MisionsCount+":"+IsNavigator+":"+IsAlive);
    }

    public void UpdateHashTablePlayer(int misionsMaxValue, int misionsCountValue, bool isNavigatorValue, bool isAliveValue)
    {
        ExitGames.Client.Photon.Hashtable ht = new ExitGames.Client.Photon.Hashtable();
        ht["misionsMax"] = misionsMaxValue;
        ht["misionsStart"] = misionsCountValue;
        ht["isNavigator"] = isNavigatorValue;
        ht["isAlive"] = isAliveValue;
        PhotonNetwork.SetPlayerCustomProperties(ht);

    }
}
