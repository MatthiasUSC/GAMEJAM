using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapePodTimer : MonoBehaviour
{
    
    float timeToEscape = 5;
    float progress = 0;
    
    public void makeProgress(){
        progress += Time.fixedDeltaTime;
        if(progress > timeToEscape){
            escape();
        }
    }

    void escape(){
        Debug.Log("Escaped!");
    }
}
