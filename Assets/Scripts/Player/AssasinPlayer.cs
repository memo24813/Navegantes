using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
public class AssasinPlayer : MonoBehaviour
{

    private Image imageKill;
    private GameObject panel;
    void Start()
    {
        bool navigator = (bool)PhotonNetwork.LocalPlayer.CustomProperties["isNavigator"];
        if( navigator == true)
            this.enabled = false;      

        panel = GameObject.FindGameObjectWithTag("kill");
        imageKill = panel.GetComponent<Image>();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            imageKill.color = Color.red;
        }
    }


    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Player"))
        {
            imageKill.color = Color.yellow;
        }
    }
}
