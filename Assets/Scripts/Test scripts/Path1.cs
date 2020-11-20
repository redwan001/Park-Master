using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
public class Path1 : MonoBehaviour
{


    public MonoBehaviour behaviour1;
    [HideInInspector]
    public LineRenderer lineRender;
  


    [HideInInspector]
    public bool drawLine1 = false;


    public List<Vector3> pionts = new List<Vector3>();

    private void Awake()
    {
        lineRender = GetComponent<LineRenderer>();
        lineRender.enabled = false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       




        if (Input.GetKey(KeyCode.Mouse0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Player1")
                {
                   
                    drawLine1 = true;
                    lineRender.enabled = true;

                }


                if (Distancetolastpiont(hit.point) > .5f && drawLine1)
                {


                    pionts.Add(hit.point);

                    lineRender.positionCount = pionts.Count;

                    lineRender.SetPositions(pionts.ToArray());
                    LineSmoother.SmoothLine(pionts.ToArray(), .1f);
                }


                if (hit.collider.tag == "Finish1")
                {
                    drawLine1 = false;
                    FindObjectOfType<CollsionDetection>().ResetPosition();
                    FindObjectOfType<LineFollower>().speed = 10;
                }



            }


        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (lineRender.enabled) {
                print("mouseup");
                behaviour1.enabled = true;
            }
            else
                behaviour1.enabled = false;

        }


    }

    public float Distancetolastpiont(Vector3 pioint)
    {

        if (!pionts.Any())
            return Mathf.Infinity;
        return Vector3.Distance(pionts.Last(), pioint);


    }

}
