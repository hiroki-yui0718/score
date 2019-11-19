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
    int score;
    int percent;
    float seconds;
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
        Debug.Log("Hit");
    }
    void OnCollisionStay(Collision collision)
    {
        seconds += Time.deltaTime;
        percent = int.Parse(per.text);
        if(seconds >= 1.0f && percent > 0)
        {
            percent -= 10;
            seconds = 0.0f;
            if (percent == 0)
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
