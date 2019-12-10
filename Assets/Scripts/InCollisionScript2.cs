using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InCollisionScript2 : MonoBehaviour
{
    public GameObject floor;
    public Text sec;
    public Text per;
    public static int percent2;
    float seconds;
    public static int score = 0;
   


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        sec.text = seconds.ToString();
        per.text = percent2.ToString();
    }
    void OnCollisionEnter(Collision collision)
    {

    }
    void OnCollisionStay(Collision collision)
    {

        seconds += Time.deltaTime;
        if (seconds >= 1.0f && percent2 < 100)
        {
            percent2 += 10;
            seconds = 0.0f;
            if (percent2 == 100)
            {
                score = 100;
                floor.gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
        }
        else if (seconds >= 3.0f && percent2 == 100)
        {
            seconds = 0.0f;
            score = 10;
        }


    }
    void OnCollisionExit(Collision other)
    {
    }
}
