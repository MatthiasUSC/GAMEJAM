using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    GameObject player;
    public float soundRadius = 5;
    float initVolume = 0;
    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
        initVolume = GetComponent<AudioSource>().volume;
    }

    void Update(){
        float dist = Vector2.Distance(player.transform.position, transform.position);
        float volMag = Mathf.Max(0, 1 - (dist / soundRadius));
        GetComponent<AudioSource>().volume = volMag * initVolume;
    }
    bool hasPlayed = false;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            if(!hasPlayed){
                GetComponent<AudioSource>().Play();
                hasPlayed = true;
            }
        }
    }
}
