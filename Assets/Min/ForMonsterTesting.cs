using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForMonsterTesting : MonoBehaviour
{
    [SerializeField] Camera cam;

    PlayerDescriptor player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerDescriptor>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseposition = cam.ScreenToWorldPoint(Input.mousePosition);
        if(mouseposition.x < -15){
            player.UpdateRoom(1);
            player.transform.position = new Vector3(-20, 0, 0);
        }
        else if(mouseposition.x < -5){
            player.UpdateRoom(2);
            player.transform.position = new Vector3(-10, 0, 0);
        }
        else if(mouseposition.x < 5){
            player.UpdateRoom(3);
            player.transform.position = new Vector3(0, 0, 0);
        }
        else if(mouseposition.x < 15){
            player.UpdateRoom(4);
            player.transform.position = new Vector3(10, 0, 0);
        }
        else {
            player.UpdateRoom(5);
            player.transform.position = new Vector3(20, 0, 0);
        }

        if(Input.GetKeyDown("space")){
            player.SetHiding(!player.IsHiding());
        }

        if(Input.GetKeyDown("s")){
            player.EncounterMonster();
        }
    }
}
