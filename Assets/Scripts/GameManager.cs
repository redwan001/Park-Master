using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject GameOverPanel;
    public GameObject NextBtn;
    Scene currentScene;
    private void OnEnable()
    {
        if (!instance)
            instance = this;

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        

    }


    public void LevelComplete()
    {
        Vector3 newPos = new Vector3(0, 0, 0);
        GameOverPanel.transform.GetComponent<RectTransform>().DOAnchorPos3D(newPos, 1.5f).SetEase(Ease.InOutElastic).OnComplete(() =>
        {
            
            NextBtn.transform.GetComponent<RectTransform>().DOScale(new Vector3(2.016701f, 3.875293f, 2.016701f), .5f);

        });
    }
     public void Reload()
    {
     
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
      

    }

    public void Reset()
    
    {
        SceneManager.LoadScene("Level1");

    }


}
