using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public GameObject firePoint;
    public List<GameObject> vfx = new List<GameObject>();
    GameObject effctspawn;
    // Start is called before the first frame update
    void Start()
    {
        effctspawn=vfx[0];
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetMouseButtonDown(0)){
           spawnVfx();
       } 
    }
    void spawnVfx(){
        GameObject vfx;
        if(firePoint != null ){
            vfx = Instantiate(effctspawn, firePoint.transform.position, Quaternion.identity);
            // Debug.Log(rotateToMouse);
            // if(rotateToMouse!= null){
            //     Debug.Log(rotateToMouse.getRotation()+"thing");
            //     vfx.transform.localRotation= rotateToMouse.getRotation();
            // }
        }
    }
}
