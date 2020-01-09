using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burn_desilove : MonoBehaviour
{
	public float speed;
	private float des = -1.2f;
	public Material mat;
	private bool ishit = false;
	private bool didLeave = false;

	void Start()
	{
		mat.SetFloat("_slide", des);
	}

	void Update()
	{
		if (ishit == true)
		{
			des += speed;

			mat.SetFloat("_slide", des);
			if (des > 2f)
			{
				ishit = false;
				Debug.Log("hit false");
			}

		}
		if (didLeave == true && ishit == false)
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
    public void burn()
	{
		ishit = true;
	}
    public void unBurn()
	{
		didLeave = true;
	}
}
