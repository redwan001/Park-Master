using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ReachGoal : MonoBehaviour
{

   
 
    public GameObject goalReachEffect;

    bool played;
    LineFollower lf;
    Scene currentScene;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        lf = GetComponent<LineFollower>();
    }


    void Update()
    {
    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<path>().drawLine = false;
            StartCoroutine(SpeedDecrease(.2f));
            Effects();
            GameManager.instance.LevelComplete();
            if (!played)
            {
                WinSound();
                played = true;
            }
         

        }
        if (other.gameObject.CompareTag("Player1"))
        {
            FindObjectOfType<Path1>().drawLine1 = false;
            // Invoke("Reload", 1.2f);         
            Invoke("DecreaseSpeed1", .5f);
            if (!played)
            {              
              
                played = true;
            }
        
        }
    }

 
    private void Effects()
    {
        Instantiate(goalReachEffect, transform);
     
    }
    void Reload() {

      
        string sceneName = currentScene.name;
        if (sceneName == "Level4")
        {
           SceneManager.LoadScene("Level1");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    IEnumerator SpeedDecrease(float waitTime)
    {
        while(true)
        {
            yield return new WaitForSeconds(waitTime);
            FindObjectOfType<LineFollower>().speed = 0;
        }
    }

    void WinSound()
    {
        SoundManager.sharedManager().PlayWinFX();
        
    }
    void DecreaseSpeed1()
    {
        FindObjectOfType<LineFollower1>().speed = 0;
    }
}
