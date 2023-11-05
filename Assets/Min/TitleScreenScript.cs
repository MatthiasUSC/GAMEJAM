using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenScript : MonoBehaviour
{
    GameObject fadetoblack_obj;

    void Start()
    {
        fadetoblack_obj = GameObject.FindWithTag("FadeToBlack");
        fadetoblack_obj.SetActive(false);
    }

    public void StartGame(){
        fadetoblack_obj.SetActive(true);
        StartCoroutine(FadeToBlackPlayAndWait());
    }

    public void ShowCredits(){

    }

    public void QuitGame(){
        Application.Quit();
    }

    IEnumerator FadeToBlackPlayAndWait(){
        Animator fadetoblackanimation = fadetoblack_obj.GetComponent<Animator>();
        fadetoblackanimation.SetTrigger("FadeToBlack");
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(1);
    }
}
