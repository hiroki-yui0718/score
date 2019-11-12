using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnTriggerScript : MonoBehaviour
{
    private int time;
    public Text scoreText;
    public static int score;
    public GameObject cube1;
    float seconds1;
    float seconds2;
    float seconds3;
    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        sw.Start();
    }
        void OnCollisionStay(Collision collision)
    {
        seconds1 += Time.deltaTime;
        if (seconds1 >= 10.0f)
        { 
            scoreText.text = (int.Parse(scoreText.text) + 100).ToString();
            cube1.gameObject.GetComponent<Renderer>().material.color = Color.red;
            Debug.Log("10秒経過");
            seconds1 = 0.0f;
        }
        seconds2 += Time.deltaTime;
        if (seconds2 >= 10.0f)
        {
            seconds3 += Time.deltaTime;
            if (seconds3 >= 3.0f)
            {
                scoreText.text = (int.Parse(scoreText.text) + 10).ToString();
                seconds3 = 0.0f;
                seconds1 = 0.0f;
                Debug.Log("3秒経過");
            }
        }

        GameObject.Find("Plus").GetComponent<Text>().text = sw.Elapsed.Seconds.ToString();
    }
    void OnCollisionExit(Collision other)
    {
        seconds1 = 0.0f;
        seconds2 = 0.0f;
        seconds3 = 0.0f;
        sw.Stop();
        sw.Reset();
        cube1.gameObject.GetComponent<Renderer>().material.color = Color.black;
    }
}
