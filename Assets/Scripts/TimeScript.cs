using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeScript : Photon.MonoBehaviour
{
    public float hensu = 100f;
    private GameObject TimeTextObj;
    public Text TimeText;
    private GameObject pauseUI;
    // Start is called before the first frame update
    void Start()
    {
    }
    void LateUpdate()
    {
        TimeText.text = ((int)hensu).ToString();
        hensu -= Time.deltaTime;
    }
    void FixedUpdate()
    { 
        if (hensu == 0)
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
    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            //データの送信
            stream.SendNext(hensu);
        }
        else
        {
            //データの受信
            this.hensu = (int)(float)stream.ReceiveNext();
        }
    }
}
