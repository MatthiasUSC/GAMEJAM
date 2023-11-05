using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGenerator : MonoBehaviour
{
    ThingsThatHappen tth;
    bool didIt = false;

    public LightingSettings currentLightingSettings;
    public GameObject lockedDoor;

    IEnumerator EmergencyLights()
    {
        while(true){
             RenderSettings.ambientLight = Color.red;
            yield return new WaitForSeconds(.1f);
            RenderSettings.ambientLight = Color.black;    
            yield return new WaitForSeconds(.5f);
        }
    }

    void Start()
    {
        tth = FindObjectOfType<ThingsThatHappen>();
    }

    void Update()
    {
        
    }

    public void DoIt()
    {
        if(!didIt){
            tth.generatorPowered = true;
            StartCoroutine(EmergencyLights());
            lockedDoor.GetComponent<DoorScript>().isLocked = false;
            didIt = true;
        }
    }
}
