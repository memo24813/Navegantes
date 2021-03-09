using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenInitialCanvas : MonoBehaviour
{
    private RoomsCanvases _roomsCanvas;


    public void FirstInitialize(RoomsCanvases canvas)
    {
        _roomsCanvas = canvas;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void OnClick_PlayGame()
    {
        _roomsCanvas.ScreenInitialCanvas.Hide();
        _roomsCanvas.SelectNickNameCanvas.Show();
    }

    public void OnClick_Exit()
    {
        Application.Quit();
    }

}
