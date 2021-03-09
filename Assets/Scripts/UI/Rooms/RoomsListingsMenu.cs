﻿using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class RoomsListingsMenu : MonoBehaviourPunCallbacks
{

    [SerializeField]
    private Transform _content;
    [SerializeField]
    private RoomListing _roomListing;

    private List<RoomListing> _listings = new List<RoomListing>();
    private RoomsCanvases _roomsCanvas;

    public void FristInitialize(RoomsCanvases canvas)
    {
        _roomsCanvas = canvas;
    }

    public override void OnJoinedRoom()
    {
        _roomsCanvas.CurrentRoomCanvas.Show();
        _roomsCanvas.CreateOrJoinRoomCanvas.Hide(); // agregue
        _content.DestroyChildren();
        _listings.Clear();
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach(RoomInfo info in roomList)
        {
            // removed from room list.
            if(info.RemovedFromList)
            {
                int index = _listings.FindIndex(x => x.RoomInfo.Name ==info.Name);
                if(index !=-1)
                {
                    Destroy(_listings[index].gameObject);
                    _listings.RemoveAt(index);
                }
            }
            else
            {
                int index = _listings.FindIndex(x => x.RoomInfo.Name == info.Name);
                if(index == -1)
                {
                    RoomListing listing = (RoomListing) Instantiate(_roomListing,_content);
                    if(listing!= null)
                    {
                        listing.SetRoomInfo(info);
                        _listings.Add(listing);
                    }
                }
                else
                {

                }
            }
        }
    }

}
