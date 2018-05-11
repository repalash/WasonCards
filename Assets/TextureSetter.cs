using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureSetter : MonoBehaviour {

	public Texture2D texture;

	// Use this for initialization
	void Start () {
		GetComponent<MeshRenderer>().material = new Material(Shader.Find("Unlit/Transparent"));
		GetComponent<MeshRenderer>().material.SetTexture("_MainTex", texture);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
