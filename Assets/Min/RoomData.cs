using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomData : MonoBehaviour
{
    [SerializeField] public int RoomNumber;
    [SerializeField] GameObject LeftVent;
    [SerializeField] GameObject RightVent;

    public int GetRoomNumber(){
        return RoomNumber;
    }

    public GameObject GetLeftVent(){
        return LeftVent;
    }

    public GameObject GetRightVent(){
        return RightVent;
    }
}
