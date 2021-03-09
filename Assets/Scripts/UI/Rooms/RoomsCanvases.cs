using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsCanvases : MonoBehaviour
{
    [SerializeField]
    private CreateOrJoinRoomCanvas _createJoinRoomCanvas;
    public CreateOrJoinRoomCanvas CreateOrJoinRoomCanvas{get{return _createJoinRoomCanvas;}}

    [SerializeField]
    private CurrentRoomCanvas _currentRoomCanvas;
    public CurrentRoomCanvas CurrentRoomCanvas{get{return _currentRoomCanvas;}}

    [SerializeField]
    private ScreenInitialCanvas _screenInitialCanvas;
    public ScreenInitialCanvas ScreenInitialCanvas{get{return _screenInitialCanvas;}}

    [SerializeField]
    private SelectNickNameCanvas _selectNickNameCanvas;
    public SelectNickNameCanvas SelectNickNameCanvas{get{return _selectNickNameCanvas;}}

    private void Awake() {
        FirstInitialize();
    }

    private void FirstInitialize()
    {
        CreateOrJoinRoomCanvas.FirstInitialize(this);
        CurrentRoomCanvas.FirstInitialize(this);

        ScreenInitialCanvas.FirstInitialize(this);
        SelectNickNameCanvas.FirstInitialize(this);
    }
}
