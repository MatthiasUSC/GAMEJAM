using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDescriptor : MonoBehaviour
{
    [SerializeField] int currRoom;
    [SerializeField] bool hiding;
    [SerializeField] bool encounteredMonster;

    void Update()
    {
        
    }

    public void UpdateRoom(int nextroom){
        currRoom = nextroom;
    }

    public int GetCurrentRoom(){
        return currRoom;
    }

    public void SetHiding(bool ishiding){
        hiding = ishiding;
    }

    public bool IsHiding(){
        return hiding;
    }

    public void EncounterMonster(){
        encounteredMonster = true;
    }

    public bool EncounteredMonster(){
        return encounteredMonster;
    }
}
