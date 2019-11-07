using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnTriggerScript : MonoBehaviour
{
    private int time;
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

        Debug.Log(sw.Elapsed.Seconds);
    }
    void OnCollisionExit(Collision other)
    {
        sw.Stop();
        int score = 0;
        score = (int)(sw.Elapsed.Seconds / 3) * 10;
        int plusScore = int.Parse(GameObject.Find("SCORE").GetComponent<Text>().text) + score;
        GameObject.Find("SCORE").GetComponent<Text>().text = plusScore.ToString();
        sw.Restart();
    }
}
