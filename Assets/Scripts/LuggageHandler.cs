using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LuggageHandler : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform luggagePos;
    public int count;
    public GameObject particles;

    bool playedl;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
  

        
    }


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Luggage"))
        {
            
            collision.transform.parent = this.transform;
            //object1 is now the child of object2
            collision.gameObject.transform.position = luggagePos.position;
            collision.transform.rotation = luggagePos.transform.rotation;
            collision.gameObject.GetComponent<BoxCollider>().enabled = false;
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            collision.transform.GetChild(1).gameObject.SetActive(false);
            collision.transform.GetChild(0).gameObject.SetActive(false);
            PickupSound();
            Explode();
            count++;
            luggagePos.position = new Vector3(luggagePos.transform.position.x, luggagePos.transform.position.y + 1 ,luggagePos.transform.position.z);
            
        }
    }


    void PickupSound()
    {
        SoundManager.sharedManager().PickUpLuggage();
    }



    public void Reset()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    void Explode()
    {
        GameObject firework = Instantiate(particles, transform);
        particles.GetComponent<ParticleSystem>().Play();
    }
}
