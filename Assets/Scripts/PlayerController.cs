using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 20; // 動く速さ

    private Rigidbody rb; // Rididbody
    private int score = 0;
    private int time;
    int kasanTime = 0;
    int count = 1;

    void Start()
    {
        // Rigidbody を取得
        rb = GetComponent<Rigidbody>();
    }
    public void FixedUpdate()
    {
        time = (int)(30.0f - Time.time);
    }

    void Update()
    {
        // カーソルキーの入力を取得
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        // カーソルキーの入力に合わせて移動方向を設定
        var movement = new Vector3(moveHorizontal, 0, moveVertical);

        // Ridigbody に力を与えて玉を動かす
        rb.AddForce(movement * speed);
    }
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Cube") || collision.gameObject.CompareTag("Cube2"))
        {
            if (kasanTime - int.Parse(GameObject.Find("Time").GetComponent<Text>().text) < 30 && kasanTime != 0)
            {
                count++;
                score += 50;
                score += 10 * count;
                GameObject.Find("SCORE").GetComponent<Text>().text = "SCORE " + score.ToString();
                Destroy(collision.gameObject);
                kasanTime = int.Parse(GameObject.Find("Time").GetComponent<Text>().text);
            }
            else
            {
                score += 50;
                GameObject.Find("SCORE").GetComponent<Text>().text = "SCORE " + score.ToString();
                Destroy(collision.gameObject);
                kasanTime = int.Parse(GameObject.Find("Time").GetComponent<Text>().text);
            }
        }

        Debug.Log("Hit"); // ログを表示する
    }
}
