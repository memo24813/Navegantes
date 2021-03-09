using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
public class SelectNickNameValidate : MonoBehaviour
{
    public TextMeshProUGUI error;
    public TMP_InputField nickNameInput;

    private RoomsCanvases _roomsCanvas;
    private void Awake() {
        error.text = "";
    }
    public void FirstInitialize(RoomsCanvases canvas)
    {
        _roomsCanvas = canvas;
    }
    public bool ValidateNickName()
    {
        return (nickNameInput.text.Length>0);
    }

    public void OnClick_Accept()
    {
        if(ValidateNickName())
        {
            PhotonNetwork.NickName = nickNameInput.text;
            Debug.Log(PhotonNetwork.LocalPlayer.NickName);
            _roomsCanvas.SelectNickNameCanvas.Hide();
            _roomsCanvas.CreateOrJoinRoomCanvas.Show();
        }
        else
        {
            nickNameInput.text = "";
            error.text = "Escribe un nombre de jugador valido.";
        }
    }

    public void OnClick_Return()
    {
        _roomsCanvas.ScreenInitialCanvas.Show();
        _roomsCanvas.SelectNickNameCanvas.Hide();
    }
}
