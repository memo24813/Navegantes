using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{


    public void LoadMainMenu()
    {
        // PhotonNetwork.ConnectUsingSettings();
        // PhotonNetwork.JoinLobby();
        SceneManager.LoadScene(0);
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}
