using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionScript : MonoBehaviour
{
    static int kasanTime = 0;
    int count = 1;
    private int score = 0;
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
        if (collision.gameObject.CompareTag("Cube") || collision.gameObject.CompareTag("Cube1") || collision.gameObject.CompareTag("Cube2"))
        {
            if (kasanTime - int.Parse(GameObject.Find("Time").GetComponent<Text>().text) < 30 && kasanTime != 0)
            {
                count++;
                score += 50;
                score += (10 * count);
                int now = int.Parse(GameObject.Find("SCORE").GetComponent<Text>().text);
                GameObject.Find("SCORE").GetComponent<Text>().text = (now + score).ToString();
                Destroy(collision.gameObject);
                kasanTime = int.Parse(GameObject.Find("Time").GetComponent<Text>().text);
                Debug.Log("1");
            }
            else
            {
                score += 50;
                int now = int.Parse(GameObject.Find("SCORE").GetComponent<Text>().text);
                GameObject.Find("SCORE").GetComponent<Text>().text = (now + score).ToString();
                Destroy(collision.gameObject);
                kasanTime = int.Parse(GameObject.Find("Time").GetComponent<Text>().text);
                Debug.Log("2");
            }
        }


        Debug.Log("Hit"); // ログを表示する
    }
}
