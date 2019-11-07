using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnTriggerScript : MonoBehaviour
{
    private int time1;
    private int time2;
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
        time1 = int.Parse(GameObject.Find("Time").GetComponent<Text>().text);
    }
    void OnCollisionStay(Collision collision)
    {
        Debug.Log("当たっている");
    }
    void OnCollisionExit(Collision other)
    {
        time2 = int.Parse(GameObject.Find("Time").GetComponent<Text>().text);
        int score = (time1 - time2) % 3 * 10;
        int plusScore = int.Parse(GameObject.Find("SCORE").GetComponent<Text>().text) + score;
        GameObject.Find("SCORE").GetComponent<Text>().text = plusScore.ToString();
    }
}
