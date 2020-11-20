using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.SceneManagement;

public class path : MonoBehaviour
{


    public MonoBehaviour behaviour;
    [HideInInspector]
    public LineRenderer lineRender;
    public Action<IEnumerable<Vector3>> onnewpathcreat = delegate { };

    [HideInInspector]public bool drawLine = false;

  
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
        print(drawLine + " drawline" );
      
        if(drawLine)
        {
            
            if (FindObjectOfType<LineFollower>().endPointReached)
                {
                print("---");
                Application.LoadLevel(Application.loadedLevel);                
                }
                    
            
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Player")
                {
                    drawLine = true;
                    lineRender.enabled = true;
                   
                }


                if (Distancetolastpiont(hit.point) > .9f && drawLine)
                {


                    pionts.Add(hit.point);
                  
                    lineRender.positionCount = pionts.Count;

                    lineRender.SetPositions(pionts.ToArray());
                    LineSmoother.SmoothLine(pionts.ToArray(), .1f);
                }


                if (hit.collider.tag == "Finish")
                {
                    drawLine = false;
                    //  onnewpathcreat(pionts);   
                    if (FindObjectOfType<CollisonDetection1>() != null)
                    {
                      //  FindObjectOfType<CollisonDetection1>().ResetPosition();
                    }
                    if (FindObjectsOfType<LineFollower1>() != null)
                    {
                       // FindObjectOfType<LineFollower1>().speed = 10;
                    }
                }



                
            }


        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            onnewpathcreat(pionts);
            if (lineRender.enabled)
              behaviour.enabled = true;
           else
              behaviour.enabled = false;

        }


    }

    public float Distancetolastpiont(Vector3 pioint)
    {

        if (!pionts.Any())
            return Mathf.Infinity;
        return Vector3.Distance(pionts.Last(), pioint);


    }

}
