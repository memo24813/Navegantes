using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectNickNameCanvas : MonoBehaviour
{

    private RoomsCanvases _roomsCanvas;

    [SerializeField]
    private SelectNickNameValidate _selectNickNameValidate;
    public void FirstInitialize(RoomsCanvases canvas)
    {
        _roomsCanvas = canvas;
        _selectNickNameValidate.FirstInitialize(canvas);
    }


    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    // public void OnClick_Return()
    // {
    //     _roomsCanvas.ScreenInitialCanvas.Show();
    //     _roomsCanvas.SelectNickNameCanvas.Hide();
    // }
}
