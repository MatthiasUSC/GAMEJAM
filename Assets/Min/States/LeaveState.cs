using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveState : MonsterState
{
    float timeLeaving;
    float timeWaited;

    public LeaveState(){
        timeLeaving = 2;
        timeWaited = 0;
    }

    int nextRoom;
    int dir;

    public void SetNextRoom(int nr, int dirHeaded){
        Debug.Log("The next room is " + nr);
        Debug.Log("Direction headed: " + dirHeaded);
        nextRoom = nr;

        RoomListing roomlisting = GameObject.FindObjectOfType<RoomListing>();
        dir = dirHeaded;
    }

    public override void Execute(MonsterBehavior monster, PlayerDescriptor target){
        timeWaited += Time.deltaTime;
        if(timeWaited >= timeLeaving){
            EnteringState es = new EnteringState();
            es.SetNextRoom(nextRoom, dir);
            monster.SetGlobalState(es);
        }
    }
}
