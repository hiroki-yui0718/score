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

        if (collision.gameObject.CompareTag("Cube"))
        {
            score += 50;
            GameObject.Find("SCORE").GetComponent<Text>().text = "SCORE " + score.ToString();
            Destroy(collision.gameObject);
        }
        if(time > 0) 
        Debug.Log("Hit"); // ログを表示する
    }
}
