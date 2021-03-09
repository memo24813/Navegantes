using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOrJoinRoomCanvas : MonoBehaviour
{
    [SerializeField]
    private CreateRoomMenu _createRoomMenu;
    [SerializeField]
    private RoomsListingsMenu _roomListingsMenu;
    private RoomsCanvases _roomsCanvas;
    public void FirstInitialize(RoomsCanvases canvas)
    {
        _roomsCanvas = canvas;
        _createRoomMenu.FirstInitialize(canvas);
        _roomListingsMenu.FristInitialize(canvas);
    }

    //por mi
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}
