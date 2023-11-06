using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGenerator : MonoBehaviour
{
    ThingsThatHappen tth;
    bool didIt = false;

    public LightingSettings currentLightingSettings;
    public GameObject lockedDoor;

    bool flashed = true;

    IEnumerator RedFlash()
    {
        flashed = false;
        RenderSettings.ambientLight = Color.red;
        yield return new WaitForSeconds(.1f);
        RenderSettings.ambientLight = Color.black; 
        yield return new WaitForSeconds(.5f);
        flashed = true;
    }


    void Start()
    {
        tth = FindObjectOfType<ThingsThatHappen>();
    }

    void Update()
    {
        if(tth.generatorPowered && flashed){
            StartCoroutine(RedFlash());
        }
    }

    public void DoIt()
    {
        if(!didIt){
            GetComponent<AudioSource>().Play();
            tth.generatorPowered = true;
            lockedDoor.GetComponent<DoorScript>().isLocked = false;
            didIt = true;
        }
    }
}
