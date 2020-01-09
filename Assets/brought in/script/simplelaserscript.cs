using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simplelaserscript : MonoBehaviour
{
    public GameObject laser;
    public GameObject firePoint;
    private GameObject spawnedlaser;

    // Start is called before the first frame update
    void Start()
    {
        spawnedlaser = Instantiate(laser, firePoint.transform) as GameObject;
        disableLaser();
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetMouseButtonDown(1)) {
         enableLaser();  
       }
       if (Input.GetMouseButton(1)) {
           updateLaser();
       }
       
       if (Input.GetMouseButtonUp(1)){
           disableLaser();
       }
    }
    void updateLaser(){
        if(firePoint!= null){
            spawnedlaser.transform.position=firePoint. transform.position;
        }
    }
    void enableLaser(){
        spawnedlaser.SetActive(true);
    }
    void disableLaser(){
        spawnedlaser.SetActive(false);
    }
}
