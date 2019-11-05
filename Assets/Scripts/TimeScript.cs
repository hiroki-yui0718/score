using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeScript : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseUI;
    // Start is called before the first frame update
    void Start()
    {

    }
    void FixedUpdate()
    {
        Text num = GameObject.Find("Time").GetComponent<Text>();
        int time = (int)(60.0f - Time.time);
        num.text = "Time:" + time;
        if (time == 0)
        {
            SceneManager.LoadScene("TimeUp");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            //　ポーズUIのアクティブ、非アクティブを切り替え
            pauseUI.SetActive(!pauseUI.activeSelf);

            //　ポーズUIが表示されてる時は停止
            if (pauseUI.activeSelf)
            {
                Time.timeScale = 0f;
                //　ポーズUIが表示されてなければ通常通り進行
            }
            else
            {
                Time.timeScale = 1f;
            }
        }
    }
    public void OnClick()
    {
        if (Time.timeScale != 0) Time.timeScale = 0;
        else Time.timeScale = 1.0f;
    }
}
