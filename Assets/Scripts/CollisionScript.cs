using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class CollisionScript :MonoBehaviour
{
    static float kasanTime = 30;
    int count = 1;
    public static int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;

    }
        // Update is called once per frame
        void Update()
    {

        kasanTime += Time.deltaTime;

    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube") || collision.gameObject.CompareTag("Cube1") || collision.gameObject.CompareTag("Cube2"))
        {
            if (kasanTime > 0 && kasanTime <= 30)
            {
                count++;
                score = 50 + (10 * count);
                Destroy(collision.gameObject);
                kasanTime = 0;
            }
            else
              {
                score = 50;
                Destroy(collision.gameObject);
                kasanTime = 0;
            }
            
        }
        Debug.Log("Hit"); // ログを表示する
    }

}
