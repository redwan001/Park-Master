using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class Missle : MonoBehaviour
{
    [SerializeField]
    Ease ease;
    [Header("Setup")]
    public Transform RocketTarget;
    public Rigidbody RocketRgb;
    public Vector3 finalRot;
    public GameObject rotatedObject , mainCar;
    public float turnSpeed = 1f;
    public float rocketFlySpeed = 10f;


    private Transform rocketLocalTrans;
    bool rotating; 




 
    void Start()
    {
        if (!RocketTarget)
            Debug.Log("Please set the Rocket Target");

        rocketLocalTrans = GetComponent<Transform>();
    }


    private void FixedUpdate()
    {
        if (!RocketRgb) //If we have not set the Rigidbody, do nothing..
            return;
        if (FindObjectOfType<ProximitySensor>().launch)
        {
            RocketRgb.velocity = rocketLocalTrans.forward * rocketFlySpeed;

            //Now Turn the Rocket towards the Target
            var rocketTargetRot = Quaternion.LookRotation(RocketTarget.position - rocketLocalTrans.position);

            RocketRgb.MoveRotation(Quaternion.RotateTowards(rocketLocalTrans.rotation, rocketTargetRot, turnSpeed));
        }
    }  // Start is called before the first frame update
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //collision.gameObject.transform.eulerAngles = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
            collision.gameObject.transform.GetChild(0).GetComponent<Animator>().enabled = false;
            collision.gameObject.GetComponent<BoxCollider>().enabled = false;
            mainCar.gameObject.transform.DORotate(finalRot, 1f).SetEase(ease);
           
            Rigidbody plRgb = collision.gameObject.GetComponent<Rigidbody>();
            if (plRgb)
            {
                plRgb.isKinematic = false;
                Vector3 force = transform.forward;
                force = new Vector3(force.x, 2, force.z);
                plRgb.AddForce(force *200);
               // plRgb.AddRelativeForce(Random.onUnitSphere * 1000);
            }
            //Deactivate Rocket..
            this.gameObject.SetActive(false);
            plRgb.constraints = RigidbodyConstraints.None;
            Instantiate(rotatedObject, collision.transform.position, Quaternion.identity);
            FindObjectOfType<path>().lineRender.enabled = false;
            FindObjectOfType<path>().behaviour.enabled = false;
            Invoke("ReloadScene", 2f);

        }
    }
    void Rotate(Vector3 angle)
    {
       
    }
    void ReloadScene()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
 
}
