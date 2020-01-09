using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desolve : MonoBehaviour
{
    public float speed;
    private float des = -1.2f;
    public Material mat;
    private bool ishit = false;
    private bool didLeave = false;
    // Start is called before the first frame update
    void Start()
    {
        mat.SetFloat("_slide", des);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("in the collstion");
        ishit = true;        
            
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log(" leaveing");
        didLeave = true;
    }
    // Update is called once per frame
    void Update()
    {   
        if(ishit == true){
          des += speed;

          mat.SetFloat("_slide", des);
            if (des > 2f)
            {
                ishit = false;
                Debug.Log("hit false");
            }
            
        }
        if(didLeave == true && ishit == false)
        {
            Debug.Log(didLeave);
            Debug.Log(" in leave");
            Debug.Log(ishit);
            des -= speed;
            mat.SetFloat("_slide", des);
            if (des < -2)
            {
                didLeave = false;
            }
        }
        
        //Debug.Log(des);
    }
}
