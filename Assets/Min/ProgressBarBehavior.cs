using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProgressBarBehavior : MonoBehaviour
{
    [SerializeField] MonsterBehavior m;

    [SerializeField] float timeToLoad;
    [SerializeField] bool holding;

    Slider progressSlider;
    float timer;

    bool monsterEntered = false;

    void Start()
    {
        progressSlider = GetComponentInChildren<Slider>();

        timer = 0;
    }

    void Update()
    {
        if (holding)
        {
            timer += Time.deltaTime;
            if(timer >= timeToLoad)
            {
                SceneManager.LoadScene(2);
            }
            else
            {
                float percentage = timer / timeToLoad;
                progressSlider.value = percentage;
                if(percentage >= .8 && !monsterEntered){
                    EnteringState es = new EnteringState();
                    es.SetNextRoom(5, 1);
                    m.SetGlobalState(es);
                    monsterEntered = true;
                }
            }
        }
        else{
            timer = 0;
        }
        if(Input.GetKeyUp(KeyCode.E)){
            holding = false;
        }
    }

    public void Holding()
    {
        holding = true;
    }

    public void Released(){
        holding = false;
    }
}
