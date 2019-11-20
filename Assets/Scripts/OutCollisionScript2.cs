using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutCollisionScript2 : MonoBehaviour
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
        GameObject.Find("Sec2-2").GetComponent<Text>().text = seconds.ToString();
    }
    void OnCollisionEnter(Collision collision)
    {

    }
    void OnCollisionStay(Collision collision)
    {
        seconds += Time.deltaTime;
        InCollisionScript2.percent2 = int.Parse(per.text);
        if (seconds >= 1.0f && InCollisionScript2.percent2 > 0)
        {
            InCollisionScript2.percent2 -= 10;
            seconds = 0.0f;
            if (InCollisionScript2.percent2 == 0)
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
