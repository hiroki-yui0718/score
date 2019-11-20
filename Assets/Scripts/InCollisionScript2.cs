using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InCollisionScript2 : MonoBehaviour
{
    public Text scoreText;
    public GameObject floor;
    public Text sec;
    public Text per;
    public static int percent2;
    float seconds;
   


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("Sec2-1").GetComponent<Text>().text = seconds.ToString();
        GameObject.Find("Per2").GetComponent<Text>().text = percent2.ToString();
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
                scoreText.text = (int.Parse(scoreText.text) + 100).ToString();
                floor.gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
        }
        else if (seconds >= 3.0f && percent2 == 100)
        {
            seconds = 0.0f;
            scoreText.text = (int.Parse(scoreText.text) + 10).ToString();
        }


    }
    void OnCollisionExit(Collision other)
    {
    }
}
