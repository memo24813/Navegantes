using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class CreateMision : MonoBehaviour
{
// 
    public GameObject prefab;
    public Canvas c;
    public Canvas message;
    
    private bool _playerColision;
    
    private int misionIndex;
    private PlayerDescription _playerDescription;

    public bool isNavigator;
    void Start()
    {
        _playerDescription = new PlayerDescription();
        misionIndex = _playerDescription.MisionsCount;
        if(isNavigator == false)
            isNavigator = (bool)PhotonNetwork.LocalPlayer.CustomProperties["isNavigator"];
        _playerColision = false;     
    }

    // Update is called once per frame
    void Update()
    {
        if(isTaskActive() && Input.GetKeyDown(KeyCode.E))
        {
            if(misionIndex ==_playerDescription.MisionsCount)
                Instantiate(prefab,c.transform);
        }

         if(misionIndex != _playerDescription.MisionsCount && _playerColision)
         {
            message.gameObject.SetActive(false);
            this.enabled = false;
         }
    }


    private void OnTriggerEnter(Collider other) {
        // if(other.CompareTag("Player") && ((bool)PhotonNetwork.LocalPlayer.CustomProperties["isNavigator"]==true))
        if(other.CompareTag("Player") && isNavigator)
        {
            misionIndex = _playerDescription.MisionsCount;
            _playerColision= true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Player"))
            _playerColision = false;   
    }


    public bool isTaskActive()
    {
        return _playerColision && !GameObject.FindWithTag("Task");
    }
}
