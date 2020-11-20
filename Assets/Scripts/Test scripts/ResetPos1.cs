using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPos1 : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector3 positionToSave;

    void Start()
    {
        positionToSave = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
