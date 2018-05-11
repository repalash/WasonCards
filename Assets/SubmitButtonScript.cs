using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmitButtonScript : MonoBehaviour
{

	public GameObject screen2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)){ // if left button pressed...
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)){
				if (hit.transform.name.Equals(transform.name))
				{
					
				}
			}
		}
	}
}
