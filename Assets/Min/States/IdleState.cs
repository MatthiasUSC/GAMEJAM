using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : MonsterState
{
    public override void Execute(MonsterBehavior monster, PlayerDescriptor target){
        //immediately transitions to searching
        monster.SetNextState(new SearchingState());
    }
}
