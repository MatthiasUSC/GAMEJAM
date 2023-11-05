using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehavior : MonoBehaviour
{
    MonsterState globalState;
    MonsterState currentState;

    [SerializeField] int currRoom;

    PlayerDescriptor target;

    float timeWaited;

    bool nearVent;

    void Start()
    {
        currentState = new BeforeActivatedState();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDescriptor>();
    }

    void Update()
    {
        if(globalState != null){
            globalState.Execute(this, target);
        }
        else{
            currentState.Execute(this, target);
        }
    }

    public void SetNextState(MonsterState nextstate){
        currentState = nextstate;
    }

    public void SetGlobalState(MonsterState nextstate){
        globalState = nextstate;
    }

    public void ReturnFromGlobal(){
        globalState = null;
    }

    public int GetCurrentRoom(){
        return currRoom;
    }

    public void SetNextRoom(int nr){
        currRoom = nr;
    }

    public bool NearVent(){
        return nearVent;
    }

    public void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Vent"){
            nearVent = true;
        }
    }

    public void OnTriggerLeave2D(Collider2D col){
        if(col.gameObject.tag == "Vent"){
            nearVent = false;
        }
    }
}
