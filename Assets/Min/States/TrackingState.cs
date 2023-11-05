using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingState : MonsterState
{   
    float timePlayerCanStay = 3;
    float timePlayerStayed = 0;
    int lastRoomPlayerWasIn;
    int dirHeaded;

    public void SetPlayersLastLocation(int ll, int dh){
        lastRoomPlayerWasIn = ll;
        dirHeaded = dh;
    }

    public override void Execute(MonsterBehavior monster, PlayerDescriptor target){
        Debug.Log("Monster is tracking in room " + monster.GetCurrentRoom());
        if(monster.GetCurrentRoom() == target.GetCurrentRoom()){
            if(!target.IsHiding()){
                monster.SetNextState(new ChaseState());
            }
            else{
                SniffState ss = new SniffState();
                ss.SetDirection(dirHeaded);
                monster.SetNextState(ss);
            }
        }
        else{
            if(target.GetCurrentRoom() != lastRoomPlayerWasIn){
                timePlayerStayed = 0;
                lastRoomPlayerWasIn = target.GetCurrentRoom();
            }
            else{
                timePlayerStayed += Time.deltaTime;
                if(timePlayerStayed >= timePlayerCanStay){
                    int dirToPlayer = -(monster.GetCurrentRoom() - target.GetCurrentRoom())/Mathf.Abs(monster.GetCurrentRoom() - target.GetCurrentRoom());
                    int nextRoom =  -dirToPlayer + target.GetCurrentRoom();
                    monster.SetNextRoom(nextRoom);
                    EnteringState es = new EnteringState();
                    es.SetNextRoom(nextRoom + dirToPlayer, dirToPlayer);
                    monster.SetGlobalState(es);
                }
            }
        }
    }
}
