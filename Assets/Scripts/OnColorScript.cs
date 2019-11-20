using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnColorScript : MonoBehaviour
{
    public GameObject Area1;
    public GameObject Area2;
    public Text ScoreText;
    public float seconds;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Area1.gameObject.GetComponent<Renderer>().material.color == Color.red && Area2.gameObject.GetComponent<Renderer>().material.color == Color.red) {

            seconds += Time.deltaTime;
/*            ScoreText.text = (int.Parse(ScoreText.text) + 50).ToString();*/
            if(seconds >= 3.0f)
            {
                ScoreText.text = (int.Parse(ScoreText.text) + 5).ToString();
            }
        }
    }
}
