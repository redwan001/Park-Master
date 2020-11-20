using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;



public class CollsionDetection : MonoBehaviour
{
    [SerializeField]
    Ease ease;
 
    public Vector3 finalRot;
    public GameObject mainCar;

    [HideInInspector]
    public bool caughtOnCam;
    void Start()
    {
        
    }


    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Wall")
        {         
            this.gameObject.transform.GetChild(0).GetComponent<Animator>().enabled = false;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            mainCar.gameObject.transform.DORotate(finalRot, 0.75f).SetEase(ease);
            Rigidbody plRgb = this.gameObject.GetComponent<Rigidbody>();
            if (plRgb)
            {
                plRgb.isKinematic = false;
                Vector3 force = transform.forward;
                force = new Vector3(-force.x,1, -force.z);
                plRgb.AddForce(force * 200);
              
            }            
            plRgb.constraints = RigidbodyConstraints.None;
            FindObjectOfType<path>().lineRender.enabled = false;
            FindObjectOfType<path>().behaviour.enabled = false;
           
            StartCoroutine(ReloadScene(2f));
        }
    
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "Cam")
        {
            print("caught");
            caughtOnCam = true;
        }
   
    }

    IEnumerator ReloadScene (float waitTime)
    {
        while(true){

            yield return new WaitForSeconds(waitTime);
            Application.LoadLevel(Application.loadedLevel);


        }
    }

    public void ResetPosition()
    {
        print("called");
        this.transform.position = FindObjectOfType<PostionSave>().positionToSave;
        FindObjectOfType<LineFollower>().currentPoint = 0;
   
    }


}
