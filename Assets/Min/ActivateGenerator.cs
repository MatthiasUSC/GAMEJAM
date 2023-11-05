using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGenerator : MonoBehaviour
{
    ThingsThatHappen tth;
    void Start()
    {
        tth = FindObjectOfType<ThingsThatHappen>();
    }

    void Update()
    {
        
    }

    public void DoIt()
    {
        tth.generatorPowered = true;
    }
}
