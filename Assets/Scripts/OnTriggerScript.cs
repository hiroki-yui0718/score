using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnTriggerScript : MonoBehaviour
{
    public Text scoreText;
    public GameObject floor;
    public Text sec;
    public Text per;
    int score;
    float seconds;
    int percent;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("Timer").GetComponent<Text>().text = seconds.ToString();
        GameObject.Find("Plus").GetComponent<Text>().text = percent.ToString();
    }
    void OnCollisionEnter(Collision collision)
    {

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
                    floor.gameObject.GetComponent<Renderer>().material.color = Color.red;
                }
            }
            else if (seconds >= 3.0f && percent == 100)
            {
                seconds = 0.0f;
                scoreText.text = (int.Parse(scoreText.text) + 10).ToString();
            }


    }
    void OnCollisionExit(Collision other)
    {
        seconds = 0;
    }
}
