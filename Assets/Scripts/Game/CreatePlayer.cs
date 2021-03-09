using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class CreatePlayer : MonoBehaviour
{
    void Start()
    {
            PhotonNetwork.Instantiate("Jugador", new Vector3(Random.Range(-7,7),0,0), Quaternion.identity);
        
    }

}
