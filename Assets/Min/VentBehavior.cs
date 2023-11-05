using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentBehavior : MonoBehaviour
{
    [SerializeField] GameObject connectedVent;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public GameObject GetConnectedVent(){
        return connectedVent;
    }
}
