using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InCollisionScript1: MonoBehaviour
{
    public GameObject floor;
    public Text sec;
    public Text per;
    public static int score = 0;
    float seconds;
    public static int percent;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        sec.text = seconds.ToString();
        per.text = percent.ToString();
    }
    void OnCollisionStay(Collision collision)
    {

        seconds += Time.deltaTime;
            if (seconds >= 1.0f && percent < 100)
            {
                percent += 10;
                seconds = 0.0f;
                if (percent == 100)
                {
                    score = 100;
                    floor.gameObject.GetComponent<Renderer>().material.color = Color.red;
                }
            }
            else if (seconds >= 3.0f && percent == 100)
            {
                seconds = 0.0f;
                score = 10;
            }


    }
}
