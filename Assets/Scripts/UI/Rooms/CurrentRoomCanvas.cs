using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentRoomCanvas : MonoBehaviour
{
    [SerializeField]
    private PlayerListingMenu _playerListingMenu;
    [SerializeField]
    private LeaveRoomMenu _leaveRoomMenu;
    public LeaveRoomMenu LeaveRoomMenu{get{return _leaveRoomMenu;}}
    private RoomsCanvases _roomsCanvas;
    public void FirstInitialize(RoomsCanvases canvas)
    {
        _roomsCanvas = canvas;
        _playerListingMenu.FirstInitialize(canvas);
        _leaveRoomMenu.FirstInitialize(canvas);
        _leaveRoomMenu.FirstInitialize(canvas);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
