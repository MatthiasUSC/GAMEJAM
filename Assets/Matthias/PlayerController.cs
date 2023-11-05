using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

    public GameObject jumpscareUI;
    public GameObject jumpscareSound;
    public bool isDead = false;
    IEnumerator deathScene(){
        jumpscareUI.GetComponent<UnityEngine.UI.Image>().enabled = true;
        jumpscareSound.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }
    public static GameObject SelectObject()
    {
        GameObject mObject = null;
        Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D mHit = Physics2D.Raycast(mRay.origin, Vector2.zero, Mathf.Infinity);
        if (mHit != null && mHit.collider != null)
        mObject = mHit.collider.gameObject;
        return mObject;
    }

    public float playerSpeed = 10;
    public GameObject popupImage;
    public GameObject playerSprite;

    public bool inLocker = false;
    private bool keyLockerReset = true;

    private bool keyDoorReset = true;


    // Update is called once per frame
    bool isPopupShowing(){
        return popupImage.GetComponent<UnityEngine.UI.Image>().enabled;
    }

    void FixedUpdate()
    {
        if(!inLocker){
            if(Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)){
                playerSprite.GetComponent<Animator>().speed = 1;
                playerSprite.GetComponent<SpriteRenderer>().flipX = true;
                GetComponent<Rigidbody2D>().velocity = new Vector2(-playerSpeed, GetComponent<Rigidbody2D>().velocity.y);
            } else if(Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A)){
                playerSprite.GetComponent<Animator>().speed = 1;
                playerSprite.GetComponent<SpriteRenderer>().flipX = false;
                GetComponent<Rigidbody2D>().velocity = new Vector2(playerSpeed, GetComponent<Rigidbody2D>().velocity.y);
            } else {
                playerSprite.GetComponent<Animator>().speed = 0;
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
            }
        } else {

        }
    }

    void Update(){
        if(!inLocker){
            if(Input.GetKeyDown(KeyCode.Mouse0)){
                if(isPopupShowing()){
                    popupImage.GetComponent<UnityEngine.UI.Image>().enabled = false;
                }
                else{
                    GameObject selected = SelectObject();
                    if(selected != null){
                        if(selected.GetComponent<ClickPopup>() != null){
                            popupImage.GetComponent<UnityEngine.UI.Image>().enabled = true;
                            popupImage.GetComponent<UnityEngine.UI.Image>().sprite = selected.GetComponent<ClickPopup>().popupSprite;
                        }
                    }
                    
                }
            }

            if(Input.GetKeyUp(KeyCode.E)){
                keyDoorReset = true;
            }
        } else {
            if(Input.GetKeyUp(KeyCode.E)){
                if(keyLockerReset == true){
                    ExitLocker();
                } else {
                    keyLockerReset = true;
                }
            }
        }
        
    }

    private void OnTriggerStay2D(Collider2D other){
        if(inLocker == false){
            if(other.tag == "Monster"){
                if(!isDead){
                    isDead = true;
                    StartCoroutine(deathScene());
                }
            } else if(other.tag == "Locker"){ // If touching locker  
                    if(Input.GetKey(KeyCode.E)){
                        keyLockerReset = false;
                        EnterLocker(other.gameObject);
                    }
            } else if(other.GetComponent<DoorScript>() != null){ // If touching door
                if(!other.GetComponent<DoorScript>().isLocked){
                    if(Input.GetKey(KeyCode.E) && keyDoorReset){
                        transform.position = other.GetComponent<DoorScript>().connectedDoor.GetComponent<DoorScript>().enterTarget.transform.position;
                        keyDoorReset = false;

                        int dir = -1;
                        if(other.tag == "RightDoor"){
                            dir = 1;
                        }
                        int currRoom = other.transform.parent.GetComponent<RoomData>().GetRoomNumber();
                        GetComponent<PlayerDescriptor>().UpdateRoom(currRoom + dir);
                    }
                }
            } else if(other.GetComponent<ActivateGenerator>() != null){
                if(Input.GetKey(KeyCode.E)){
                    other.GetComponent<ActivateGenerator>().DoIt();
                }
            } else if(other.GetComponent<ProgressBarBehavior>() != null){
                if(Input.GetKey(KeyCode.E)){
                    other.GetComponent<ProgressBarBehavior>().Holding();
                }
            } 
        }
    }

    private void ExitLocker(){
        playerSprite.GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        inLocker = false;
        GetComponent<PlayerDescriptor>().SetHiding(false);
    }

    private void EnterLocker(GameObject locker){
        transform.position = locker.transform.position;
        inLocker = true;
        playerSprite.GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        GetComponent<PlayerDescriptor>().SetHiding(true);
    }
}
