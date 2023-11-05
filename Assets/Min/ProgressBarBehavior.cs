using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarBehavior : MonoBehaviour
{
    [SerializeField] float timeToLoad;
    [SerializeField] bool started;

    Slider progressSlider;
    float timer;

    void Start()
    {
        progressSlider = GetComponentInChildren<Slider>();

        timer = 0;
    }

    void Update()
    {
        if (started)
        {
            timer += Time.deltaTime;
            if(timer >= timeToLoad)
            {
                Debug.Log("FINISHED!");
                //load the next scene
            }
            else
            {
                float percentage = timer / timeToLoad;
                progressSlider.value = percentage;
            }
        }
    }

    public void StartProgress()
    {
        started = true;
    }
}
