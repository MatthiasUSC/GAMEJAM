using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchingState : MonsterState
{   
    float timeInBetween;
    float timeWaited;

    public SearchingState(){
        timeInBetween = 2;
        timeWaited = 0;
    }

    public override void Execute(MonsterBehavior monster, PlayerDescriptor target){
        Debug.Log("Monster is searching in room " + monster.GetCurrentRoom());
        if(target.GetCurrentRoom() == monster.GetCurrentRoom() && !target.IsHiding()){
            monster.SetNextState(new ChaseState());
        }
        else{
            timeWaited += Time.deltaTime;
            if(timeWaited >= timeInBetween){
                int randDir = Random.Range(0, 2); if(randDir == 0) randDir = -1;
                int nextRoom = monster.GetCurrentRoom() + randDir;
                if(nextRoom == 0) {nextRoom = 2; randDir = 1;}
                else if(nextRoom == 6) {nextRoom = 4; randDir = -1;}
                EnteringState es = new EnteringState();
                es.SetNextRoom(nextRoom, randDir);
                monster.SetGlobalState(es);
                timeWaited = 0;
            }
        }
    }
}
