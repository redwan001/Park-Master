using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class CamRotator : MonoBehaviour
{
    public float speed = 2f;
    public Vector3 finalPos;
    public GameObject policeCar;
    public Vector3 finalRot;
    public GameObject pole;
    public float spriteBlinkingTimer = 0.0f;
    public float spriteBlinkingMiniDuration = 0.1f;
    public float spriteBlinkingTotalTimer = 0.0f;
    public float spriteBlinkingTotalDuration = 1.0f;
    public bool startBlinking = false;
    public float maxRotation = 45f;
    bool played;
    public SpriteRenderer sr;

    void Update()
    {
        if (FindObjectOfType<CollsionDetection>().caughtOnCam)
        {
            Invoke("ReloadScene", 4);

            speed = 0;
            SpriteBlinkingEffect();
            policeCar.gameObject.SetActive(true);
            policeCar.transform.DOMove(finalPos, 3f);           
            SoundManager.sharedManager().SirenSound();
            pole.transform.DORotate(new Vector3(0,-180,0) , 1);
        }
        transform.rotation = Quaternion.Euler(0, maxRotation * Mathf.Sin(Time.time * speed), 0f);
    }



    private void SpriteBlinkingEffect()
    {
        spriteBlinkingTotalTimer += Time.deltaTime;
        if (spriteBlinkingTotalTimer >= spriteBlinkingTotalDuration)
        {
            startBlinking = false;
            spriteBlinkingTotalTimer = 0.0f;
           sr.enabled = true;   // according to 
                                                                             //your sprite
            return;
        }

        spriteBlinkingTimer += Time.deltaTime;
        if (spriteBlinkingTimer >= spriteBlinkingMiniDuration)
        {
            spriteBlinkingTimer = 0.0f;
            if (sr.enabled == true)
            {
                sr.enabled = false;  //make changes
            }
            else
            {
              sr.enabled = true;   //make changes
            }
        }
    }
    void ReloadScene()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
