using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionScript : MonoBehaviour
{
    public Text Score;
    static float kasanTime = 30;
    int count = 1;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        kasanTime+= Time.deltaTime;

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube") || collision.gameObject.CompareTag("Cube1") || collision.gameObject.CompareTag("Cube2"))
        {
            if (kasanTime > 0 && kasanTime <= 30)
            {
                count++;
                score += 50;
                score += (10 * count);
                Score.text = (int.Parse(Score.text) + score).ToString();
                Destroy(collision.gameObject);
                kasanTime = 0;
            }
            else
            {
                score += 50;
                Score.text = (int.Parse(Score.text) + score).ToString();
                Destroy(collision.gameObject);
                kasanTime = 0;
            }
        }


        Debug.Log("Hit"); // ログを表示する
    }
}
