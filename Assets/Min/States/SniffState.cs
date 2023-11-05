using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniffState : MonsterState
{
    float sniffAroundSpeed;
    int dirHeaded;

    GameObject destVent;
    bool turnaround;
    float timeBeforeTurnAround;
    float timeWalked;

    public void SetDirection(int dh){
        dirHeaded = dh;
        sniffAroundSpeed = 1;
        turnaround = false;
        timeBeforeTurnAround = 3;
        timeWalked = 0;
    }
    
    public override void Execute(MonsterBehavior monster, PlayerDescriptor target){
        Debug.Log("Monster is sniffing in room " + monster.GetCurrentRoom());
        if(!target.IsHiding()){ // player is in sight
            monster.SetNextState(new ChaseState());
        }
        else{
            if(destVent == null){
                RoomListing roomlisting = GameObject.FindObjectOfType<RoomListing>();
                if(dirHeaded > 0){ // moving right
                    GameObject rightVent = roomlisting.GetRoomData(monster.GetCurrentRoom()).GetRightVent();
                    if(rightVent == null){
                        destVent = roomlisting.GetRoomData(monster.GetCurrentRoom()).GetLeftVent();
                        turnaround = true;
                    }
                    else{
                        destVent = rightVent;
                    }
                }
                else{
                    GameObject leftVent = roomlisting.GetRoomData(monster.GetCurrentRoom()).GetLeftVent();
                    if(leftVent == null){
                        destVent = roomlisting.GetRoomData(monster.GetCurrentRoom()).GetRightVent();
                        turnaround = true;
                    }
                    else{
                        destVent = leftVent;
                    }
                }
            }
            else{
                if(turnaround){
                    timeWalked += Time.deltaTime;
                    if(timeWalked >= timeBeforeTurnAround){
                        dirHeaded = -dirHeaded;
                        turnaround = false;
                    }
                    float xvel = dirHeaded * sniffAroundSpeed;
                    monster.transform.position += new Vector3(xvel, 0, 0) * Time.deltaTime;
                }
                else{
                    if(Mathf.Abs(monster.transform.position.x - destVent.transform.position.x) <= 0.01){
                        LeaveState es = new LeaveState();
                        es.SetNextRoom(monster.GetCurrentRoom() + dirHeaded, dirHeaded);
                        monster.SetNextState(new SearchingState());
                        monster.SetGlobalState(es);
                    }
                    else{
                        float xvel = dirHeaded * sniffAroundSpeed;
                        monster.transform.position += new Vector3(xvel, 0, 0) * Time.deltaTime;
                    }
                }
            }
        }
    }
}
