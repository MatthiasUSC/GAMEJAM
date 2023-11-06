using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PostScene : MonoBehaviour
{
    public GameObject winMusic;
    public GameObject pod;

    public GameObject endImage;

    IEnumerator scene(){
        winMusic.GetComponent<AudioSource>().Play();
        pod.GetComponent<Rigidbody2D>().velocity = Vector2.right;
        yield return new WaitForSeconds(20f);
        endImage.GetComponent<Image>().enabled = true;
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
    }


    void Start()
    {
        StartCoroutine(scene());
    }
}
