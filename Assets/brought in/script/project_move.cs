using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class project_move : MonoBehaviour
{
    public float speed;
    public float fireRate;
    public GameObject muzzle;
    public GameObject heat;

    public float xAngle, yAngle, zAngle;

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
     if (muzzle!=null){
         var muzzlevfx =Instantiate(muzzle, transform.position, Quaternion.identity);
         muzzlevfx.transform.forward=gameObject.transform.forward;
         var psmuzzle= muzzlevfx.GetComponent<ParticleSystem>();
         if(psmuzzle!=null){
             Destroy(muzzlevfx, psmuzzle.main.duration);
         }else
         {
             var psChild= muzzlevfx.transform.GetChild(0).GetComponent<ParticleSystem>();
                          Destroy(muzzlevfx, psChild.main.duration);

         }
     }  
    }

    // Update is called once per frame
    void Update()
    {
    if(speed!=0){
        transform.position += transform.forward* (speed* Time.deltaTime);
    }        
    }
    private void OnCollisionEnter(Collision co) {
     speed=0;   
     ContactPoint contact = co.contacts[0];
     Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
     Vector3 pos = contact.point;
     if(heat!=null ){
        var heatvfx =Instantiate(heat,pos, rot);
     var psheat= heatvfx.GetComponent<ParticleSystem>();
         if(psheat!=null){
             Destroy(heatvfx, psheat.main.duration);
         }else
         {
             var psChild= heatvfx.transform.GetChild(0).GetComponent<ParticleSystem>();
                          Destroy(heatvfx, psChild.main.duration);

         } 
     }
     Destroy(gameObject);
    }
}
