using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class TimeScript : MonoBehaviour
{
    [SerializeField]
    public GameObject pauseUI; //当てはめないといけない
    public static float time = 100f;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.5f;
    }

    void FixedUpdate()
    {

        time -= Time.deltaTime;
        if (time <= 0)
        {
            SceneManager.LoadScene("TimeUp");
        }
    }
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
