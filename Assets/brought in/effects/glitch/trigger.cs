using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    MeshRenderer mat;
    float dsiAmount;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        dsiAmount = Mathf.Lerp(dsiAmount, 0, Time.deltaTime);
        mat.material.SetFloat("_amount", dsiAmount);
        if (Input.GetKeyDown("p"))
        {
            dsiAmount += 1f;
        }
        
    }
}
