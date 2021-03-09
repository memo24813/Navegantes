using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Emergencia : MonoBehaviour
{
    public GameObject prefabChat;
    private GameObject [] players;

    public GameObject position;

    private PhotonView _pv;
    void Start()
    {
        _pv = GetComponent<PhotonView>();
        _pv.RPC("spawnPlayers",RpcTarget.All);
        getPlayers();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void getPlayers()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    [PunRPC]
    public void spawnPlayers()
    {
        getPlayers();
        foreach (GameObject player in players)
        {
               player.transform.position = new Vector3(position.transform.position.x + Random.Range(-10,10),player.transform.position.y,position.transform.position.z+ Random.Range(-10,10)); 
        }

        prefabChat.SetActive(true);
    }


    public void disableControls()
    {
        foreach (GameObject player in players)
        {
           player.SetActive(false); 
        }
    }

    public void activateControls()
    {
        foreach (GameObject player in players)
        {
            player.SetActive(true);
        }
    }
}
