using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnteringState : MonsterState
{
    float timeEntering;
    float timeWaited;
    GameObject nextVent;

    bool anim_triggered;

    public EnteringState(){
        timeEntering = 1;
        timeWaited = 0;
    }

    int nextRoom;

    public void SetNextRoom(int nr, int dirHeaded){
        Debug.Log("The next room is " + nr);
        Debug.Log("Direction headed: " + dirHeaded);
        nextRoom = nr;

        anim_triggered = false;

        RoomListing roomlisting = GameObject.FindObjectOfType<RoomListing>();
        if(dirHeaded > 0) {// headed  right
            nextVent = roomlisting.GetRoomData(nextRoom).GetLeftVent();
        }
        else{
            nextVent = roomlisting.GetRoomData(nextRoom).GetRightVent();
        }
    }

    public override void Execute(MonsterBehavior monster, PlayerDescriptor target){
        monster.SetNextRoom(nextRoom);
        monster.transform.position = nextVent.transform.position;
        if(!anim_triggered){
            monster.GetComponentInChildren<Animator>().SetTrigger("MonsterEnter");
            anim_triggered = true;
        }
        timeWaited += Time.deltaTime;
        if(timeWaited >= timeEntering){
            monster.SetGlobalState(null);
        }
    }
}
