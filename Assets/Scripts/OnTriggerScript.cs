using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnTriggerScript : MonoBehaviour
{
    private int time;
    private int score;
    public GameObject cube1;
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
        time = sw.Elapsed.Seconds;
        if (time > 10)
        {
            cube1.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }

        GameObject.Find("Plus").GetComponent<Text>().text = sw.Elapsed.Seconds.ToString();
    }
    void OnCollisionExit(Collision other)
    {
//        if (time == 10)
//        {
//            score = 100;
//            int plusScore = int.Parse(GameObject.Find("SCORE").GetComponent<Text>().text) + score;
//            GameObject.Find("SCORE").GetComponent<Text>().text = plusScore.ToString();
//        }

        if (time > 10)
        {
     
            score = 100 + (int)((sw.Elapsed.Seconds-10) / 3) * 10;
            int plusScore = int.Parse(GameObject.Find("SCORE").GetComponent<Text>().text) + score;
            GameObject.Find("SCORE").GetComponent<Text>().text = plusScore.ToString();
         
        }
        sw.Stop();
        sw.Reset();
        cube1.gameObject.GetComponent<Renderer>().material.color = Color.black;
    }
}
