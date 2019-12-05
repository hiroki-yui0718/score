﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class TimeScript : MonoBehaviourPunCallbacks, IPunObservable
{
    private float hensu = 100f;
    public Text TimeText;
    private GameObject pauseUI;
    // Start is called before the first frame update
    void Start()
    {
    }
    void Update()
    {
        TimeText.text = ((int)hensu).ToString();
        hensu -= Time.deltaTime;
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
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(hensu);
            
        }
        // オーナー以外の場合
        else
        {
            this.hensu = (int)(float)(stream.ReceiveNext());
            
        }
    }
    void FixedUpdate() {
        if (hensu == 0)
        {
            SceneManager.LoadScene("TimeUp");
        }
    }
    public void OnClick()
    {
        if (Time.timeScale != 0) Time.timeScale = 0;
        else Time.timeScale = 1.0f;
    }
}
