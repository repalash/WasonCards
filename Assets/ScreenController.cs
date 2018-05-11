using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScreenController : MonoBehaviour
{

    public CardSetController[] o;

    private bool explained;

    public MeshRenderer correct, incorrect, explain, t2, t1;
    
	
    public Texture2D[] p_ts;
    public Texture2D[] np_ts;
    public Texture2D[] q_ts;
    public Texture2D[] nq_ts;

    // Use this for initialization
    void Awake ()
    {
        explained = false;
        System.Random rnd = new System.Random();
        int m = 0;
        foreach (var i in Enumerable.Range(0, 4).OrderBy(c => rnd.Next()).ToArray())
        {
            if (m == 0)
            {
                o[i].p_ts = p_ts;
                o[i].np_ts = np_ts;
                o[i].q_ts = q_ts;
                o[i].nq_ts = nq_ts;
                o[i].p.correct = true;
                o[i].np.correct = false;
            }else if (m == 1)
            {
                o[i].p_ts = np_ts;
                o[i].np_ts = p_ts;
                o[i].q_ts = q_ts;
                o[i].nq_ts = nq_ts;
                o[i].p.correct = true;
                o[i].np.correct = true;			
            }else if (m == 2)
            {
                o[i].p_ts = q_ts;
                o[i].np_ts = nq_ts;
                o[i].q_ts = p_ts;
                o[i].nq_ts = np_ts;
                o[i].p.correct = true;
                o[i].np.correct = true;			
            }else if (m == 3)
            {
                o[i].p_ts = nq_ts;
                o[i].np_ts = q_ts;
                o[i].q_ts = p_ts;
                o[i].nq_ts = np_ts;
                o[i].p.correct = false;
                o[i].np.correct = true;
            }
            m += 1;
        }
    }
	
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Evaluate();
        }
    }

    public void Evaluate()
    {
        int nt = 0;
        for (int i = 0; i < 4; i++)
        {
            if (o[i].mainCard.clicked && !(o[i].p.correct && o[i].np.correct))
            {
                nt += 1;
            }else if (o[i].mainCard.clicked) nt = -5;
        }
        
        if (nt == 2)
        {
            correct.enabled = true;
            explain.enabled = true;
            incorrect.enabled = false;
        }
        else
        {
            incorrect.enabled = true;
            explain.enabled = true;
            correct.enabled = false;
        }

    }

    public IEnumerator Explain()
    {
        if(explained) yield break;
        explained = true;
        correct.enabled = false;
        incorrect.enabled = false;
        t2.enabled = false;
        t1.enabled = false;
        yield return SelectAll();
        yield return ExpandAll();
    }

    public IEnumerator SelectAll()
    {
        StartCoroutine(o[0].mainCard.SelectMe());
        StartCoroutine(o[1].mainCard.SelectMe());
        StartCoroutine(o[2].mainCard.SelectMe());
        yield return (o[3].mainCard.SelectMe());
    }
    public IEnumerator ExpandAll()
    {
        StartCoroutine(o[0].mainCard.Expand());
        StartCoroutine(o[1].mainCard.Expand());
        StartCoroutine(o[2].mainCard.Expand());
        yield return (o[3].mainCard.Expand());
    }
}