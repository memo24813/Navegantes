using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
public class NickNameScene : MonoBehaviour
{
    public Text nickName;
    void Start()
    {
        nickName.text = PhotonNetwork.NickName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
