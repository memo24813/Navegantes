using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
public class ViewStatsPlayer : MonoBehaviour
{

    private int misionsMax;
    private int misionsStart;
    private bool isAlive;
    private bool isNavigator;

    public Text player,misioneMax,misionStart,Alive,Navigator;
    
            // _myCustomProperties.Add("misionsMax",misionsMax);
            // _myCustomProperties.Add("misionsStart",misionsMax);
            // _myCustomProperties.Add("isAlive",isAlive);
            // _myCustomProperties.Add("isNavigator",isNavigator);
    void Start()
    {
        misionsMax = (int) PhotonNetwork.LocalPlayer.CustomProperties["misionsMax"];
        misionsStart = (int) PhotonNetwork.LocalPlayer.CustomProperties["misionsStart"];
        isAlive = (bool) PhotonNetwork.LocalPlayer.CustomProperties["isAlive"];
        isNavigator = (bool) PhotonNetwork.LocalPlayer.CustomProperties["isNavigator"];

        player.text = PhotonNetwork.NickName;
        misioneMax.text = "Misiones maximas: "+misionsMax;
        misionStart.text = "Misiones echas: "+misionsStart;
        Alive.text = (isAlive)?"Vivo":"Muerto";
        Navigator.text = (isNavigator)?"Navegante":"Traidor";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
