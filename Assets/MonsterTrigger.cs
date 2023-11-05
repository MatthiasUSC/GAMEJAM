using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTrigger : MonoBehaviour
{
    bool isTriggered = false;
    private void OnTriggerStay2D(Collider2D other){
        if(other.tag == "Player"){
            if(!isTriggered){
                isTriggered = true;
                other.GetComponent<PlayerDescriptor>().EncounterMonster();
            }
        }
    }
}
