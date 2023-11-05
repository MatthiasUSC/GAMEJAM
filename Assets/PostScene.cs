using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PostScene : MonoBehaviour
{
    public GameObject winMusic;
    public GameObject pod;

    IEnumerator scene(){
        winMusic.GetComponent<AudioSource>().Play();
        pod.GetComponent<Rigidbody2D>().velocity = Vector2.right;
        yield return new WaitForSeconds(20f);
        SceneManager.LoadScene(0);
    }


    void Start()
    {
        StartCoroutine(scene());
    }
}
