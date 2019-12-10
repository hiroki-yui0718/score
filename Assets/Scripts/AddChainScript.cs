using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddChainScript : MonoBehaviour
{
    public GameObject Area1;
    public GameObject Area2;
    public Text ScoreText;
    public float seconds;
    bool flg = true;
    public static int score = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Area1.gameObject.GetComponent<Renderer>().material.color == Color.red && Area2.gameObject.GetComponent<Renderer>().material.color == Color.red)
        {
            if (flg)
            {
                flg = false;
                score = 50;
            }
                seconds += Time.deltaTime;
                if (seconds >= 3.0f)
                {
                    score = 5;
                    seconds = 0;
                }
            

        }

        
    
        
    }
}
