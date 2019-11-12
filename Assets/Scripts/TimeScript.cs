using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeScript : NetworkBehaviour
{

    [SyncVar]
    int time = 0;

    [SerializeField]
    private GameObject pauseUI;
    // Start is called before the first frame update
    void Start()
    {

    }
    void FixedUpdate()
    {
        Text num = GameObject.Find("Time").GetComponent<Text>();
        time = (int)(60.0f - Time.time);
        num.text = time.ToString();
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
}
