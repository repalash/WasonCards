using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSetController : MonoBehaviour
{

	public CardController mainCard;
	public CardController p;
	public CardController np;

	public Texture2D[] p_ts;
	public Texture2D[] np_ts;
	public Texture2D[] q_ts;
	public Texture2D[] nq_ts;
	
	// Use this for initialization
	void Start ()
	{
		mainCard.front = p_ts[Random.Range(0, p_ts.Length)];
		p.front = mainCard.front;
		np.front = mainCard.front;
		
		p.back = q_ts[Random.Range(0, q_ts.Length)];
		np.back = nq_ts[Random.Range(0, nq_ts.Length)];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
