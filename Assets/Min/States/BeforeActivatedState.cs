using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeforeActivatedState : MonsterState
{
    public override void Execute(MonsterBehavior monster, PlayerDescriptor target){
        if(target.EncounteredMonster()){
            monster.SetNextState(new IdleState());
        }
    }
}
