using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class CollisonDetection1 : MonoBehaviour
{
    [SerializeField]
    Ease ease;

    public Vector3 finalRot;
    public GameObject mainCar;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            this.gameObject.transform.GetChild(0).GetComponent<Animator>().enabled = false;
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            mainCar.gameObject.transform.DORotate(finalRot, 0.75f).SetEase(ease);

            Rigidbody plRgb = this.gameObject.GetComponent<Rigidbody>();
            if (plRgb)
            {
                plRgb.isKinematic = false;
                Vector3 force = transform.forward;
                force = new Vector3(-force.x, 1, -force.z);
                plRgb.AddForce(force * 200);

            }

            plRgb.constraints = RigidbodyConstraints.None;
            // Instantiate(rotatedObject, collision.transform.position, Quaternion.identity);
            FindObjectOfType<path>().lineRender.enabled = false;
            FindObjectOfType<path>().behaviour.enabled = false;
            Invoke("ReloadScene", 2f);
        }

    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
        }

    }
    void ReloadScene()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void ResetPosition()
    {
        print("called");
        this.transform.position = FindObjectOfType<ResetPos1>().positionToSave;
        FindObjectOfType<LineFollower1>().currentPoint = 0;

    }
}




