using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CarControl : MonoBehaviour
{
    private float rotateSpeed = 90;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed, Space.Self);
    }

}
