using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    private ExitGames.Client.Photon.Hashtable _myCustomProperties = new ExitGames.Client.Photon.Hashtable();
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        foreach (Player item in PhotonNetwork.PlayerList)
        {
            Debug.Log(item.NickName);
        }
    }
}
