using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingState : MonsterState
{   
    float timePlayerCanStay = 3;
    float timePlayerStayed = 0;
    int lastRoomPlayerWasIn;

    public void SetPlayersLastLocation(int ll){
        lastRoomPlayerWasIn = ll;
    }

    public override void Execute(MonsterBehavior monster, PlayerDescriptor target){
        Debug.Log("Monster is tracking in room " + monster.GetCurrentRoom());
        if(monster.GetCurrentRoom() == target.GetCurrentRoom()){
            if(!target.IsHiding()){
                monster.SetNextState(new ChaseState());
            }
            else{
                int dirToPlayer = -(monster.GetCurrentRoom() - target.GetCurrentRoom())/Mathf.Abs(monster.GetCurrentRoom() - target.GetCurrentRoom());
                SniffState ss = new SniffState();
                ss.SetDirection(dirToPlayer);
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
