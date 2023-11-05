using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomListing : MonoBehaviour
{
    [SerializeField] List<RoomData> rooms;

    void Start(){
        rooms.Add(null);
        RoomData[] roomdatas = FindObjectsOfType<RoomData>();
        for(int i = 1;i<=5;i++){
            foreach(RoomData room in roomdatas){
                if(room.GetRoomNumber() == i) {
                    rooms.Add(room);
                }
            }
        }
    }

    public RoomData GetRoomData(int roomnumber){
        return rooms[roomnumber];
    }
}
