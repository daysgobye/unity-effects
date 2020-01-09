using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire_ball : MonoBehaviour
{
    public GameObject vfx;
    public Transform startPoint;
    public Transform endPoint;

    // Start is called before the first frame update
    void Start()
    {
        var startPos = startPoint.position;
        GameObject objVfx= Instantiate(vfx, startPos, Quaternion.identity)as GameObject;
        var endpos = endPoint.position;
        RotateTo(objVfx, endpos);
    }
void RotateTo(GameObject obj, Vector3 dest){
    var direction = dest- obj.transform.position;
    var rotation=Quaternion.LookRotation(direction);
    obj.transform.localRotation=Quaternion.Lerp(obj.transform.rotation, rotation, 1);
}
    // Update is called once per frame
    void Update()
    {
        
    }
}
