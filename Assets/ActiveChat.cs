using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveChat : MonoBehaviour
{
    
    private int misionIndex;
    public GameObject chat;
    private bool _playerColision;
    void Start()
    {
        chat.SetActive(false);
        _playerColision = false;     
    }

    // Update is called once per frame
    void Update()
    {
        if(isTaskActive() && Input.GetKeyDown(KeyCode.E))
        {
            chat.SetActive(true);
        }
    }


    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            _playerColision= true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Player"))
            _playerColision = false;  
            // chat.SetActive(false); 
    }


    public bool isTaskActive()
    {
        return _playerColision && !GameObject.FindWithTag("Task");
    }
}
