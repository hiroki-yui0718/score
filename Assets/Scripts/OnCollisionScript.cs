using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnCollisionScript : MonoBehaviour
{
    public Text scoreText;
    public GameObject floor;
    public Text sec;
    public Text per;
    public static int score;
    public static int percent;
    float seconds;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("Sec2").GetComponent<Text>().text = seconds.ToString();
    }
    void OnCollisionEnter(Collision collision)
    {

    }
    void OnCollisionStay(Collision collision)
    {
        seconds += Time.deltaTime;
        OnTriggerScript.percent = int.Parse(per.text);
        if (seconds >= 1.0f && OnTriggerScript.percent > 0)
        {
            OnTriggerScript.percent -= 10;
            seconds = 0.0f;
            if (OnTriggerScript.percent == 0)
            {
                floor.gameObject.GetComponent<Renderer>().material.color = Color.black;
            }
        }
    }
    void OnCollisionExit(Collision other)
    {
        seconds = 0;
    }
}
