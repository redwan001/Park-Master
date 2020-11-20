using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{

    public GameObject Fx;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
   
    }




    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Fx != null)
            {
                Fx.gameObject.SetActive(true);
            }
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Fx != null)
            {
                Fx.gameObject.SetActive(false);
            }
        }
    }
}
