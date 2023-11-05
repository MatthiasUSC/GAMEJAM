using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{

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


    // Update is called once per frame
    bool isPopupShowing(){
        return popupImage.GetComponent<UnityEngine.UI.Image>().enabled;
    }

    void FixedUpdate()
    {
        if(!inLocker){
            if(Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)){
                GetComponent<Rigidbody2D>().velocity = new Vector2(-playerSpeed, GetComponent<Rigidbody2D>().velocity.y);
            } else if(Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A)){
                GetComponent<Rigidbody2D>().velocity = new Vector2(playerSpeed, GetComponent<Rigidbody2D>().velocity.y);
            } else {
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
        if(other.tag == "Locker"){
            if(inLocker == false){
                if(Input.GetKey(KeyCode.E)){
                    keyLockerReset = false;
                    EnterLocker(other.gameObject);
                }
            } 
        }
    }

    private void ExitLocker(){
        playerSprite.GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        inLocker = false;
    }

    private void EnterLocker(GameObject locker){
        transform.position = locker.transform.position;
        inLocker = true;
        playerSprite.GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
    }
}
