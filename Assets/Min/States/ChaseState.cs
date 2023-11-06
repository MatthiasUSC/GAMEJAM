using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : MonsterState
{
    float movespeed;

    public ChaseState(){
        movespeed = 3;
    }

    public override void Execute(MonsterBehavior monster, PlayerDescriptor target){
        Debug.Log("Monster is chasing in room " + monster.GetCurrentRoom());
        if(target.GetCurrentRoom() != monster.GetCurrentRoom()){
            monster.GetComponentInChildren<Animator>().SetBool("MonsterMove", false);
            int dirToPlayer = -(monster.GetCurrentRoom() - target.GetCurrentRoom())/Mathf.Abs(monster.GetCurrentRoom() - target.GetCurrentRoom());
            TrackingState ts = new TrackingState();
            ts.SetPlayersLastLocation(target.GetCurrentRoom(), dirToPlayer);
            monster.SetNextState(ts);
        }
        else{
            Rigidbody2D playerrb = target.GetComponent<Rigidbody2D>();
            Vector2 monsterpos = monster.transform.position;

            float xvelocity = (playerrb.position.x - monsterpos.x)/ Mathf.Abs(playerrb.position.x - monsterpos.x) * movespeed;
            monster.transform.position += new Vector3(xvelocity, 0, 0) * Time.deltaTime;
                    monster.GetComponentInChildren<Animator>().SetBool("MonsterMove", true);
        }
    }
}
