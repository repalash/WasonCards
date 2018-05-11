using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CardController : MonoBehaviour {

	public Texture2D front, back;
	public MeshRenderer frontM, backM;
	public GameObject p, notP;

	public bool clicked = false;

	private bool flipped;

	public bool correct;
	
	// Use this for initialization
	IEnumerator Start ()
	{
		yield return null;
		flipped = false;
		frontM.sharedMaterial = new Material(Shader.Find("Unlit/Texture"));
		frontM.sharedMaterial.SetTexture("_MainTex", front);
		backM.sharedMaterial = new Material(Shader.Find("Unlit/Texture"));
		backM.sharedMaterial.SetTexture("_MainTex", back);
		Material mat = new Material(Shader.Find("Unlit/Color"));
		mat.SetColor("_Color", new Color(1, 1, 0.85f));
		frontM.transform.parent.GetComponent<MeshRenderer>().sharedMaterial = mat;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)){ // if left button pressed...
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)){
				if (hit.transform.parent && hit.transform.parent.parent && hit.transform.parent.parent.name.Equals(transform.parent.name))
				{
					StartCoroutine(SelectMe());
				}
			}
		}
	}

	public IEnumerator SelectMe()
	{
		if (clicked) yield break;
		clicked = true;
		for (int i = 0; i < 180; i+=10)
		{
//			transform.eulerAngles = new Vector3(0, i, 0);
			transform.parent.position += new Vector3(0, 0.04f, 0);
			yield return new WaitForSecondsRealtime(0.01f);
		}
	}

	public IEnumerator FlipMe()
	{
		if (flipped) yield break;
		flipped = true;
		for (int i = 0; i < 180; i+=5)
		{
			transform.eulerAngles = new Vector3(0, i, 180);
			yield return new WaitForSecondsRealtime(0.01f);
		}
		yield return new WaitForSecondsRealtime(0.5f);
		Material mat = new Material(Shader.Find("Unlit/Color"));
		mat.SetColor("_Color", !clicked?Color.white:correct?Color.green:Color.red);
		frontM.transform.parent.GetComponent<MeshRenderer>().sharedMaterial = mat;
	}

	public IEnumerator Expand()
	{
		for (int i = 0; i < 400; i+=10)
		{
			p.transform.position -= new Vector3(0, 0.1f, 0);
			notP.transform.position -= new Vector3(0, 0.1f, 0);
			yield return new WaitForSecondsRealtime(0.01f);
		}
		for (int i = 0; i < 300; i+=10)
		{
			notP.transform.position -= new Vector3(0, 0.1f, 0);
			yield return new WaitForSecondsRealtime(0.01f);
		}

		StartCoroutine(p.GetComponent<CardController>().FlipMe());
		StartCoroutine(notP.GetComponent<CardController>().FlipMe());
	}
}
