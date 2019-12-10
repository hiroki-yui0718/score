using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class TimeSync : MonoBehaviourPunCallbacks
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PhotonView photonView = GetComponent<PhotonView>(); //①必ずPhotonViewをマウンド
        if (photonView.IsMine == false) //②なぜかTrueにならない
        {
            Debug.Log("True1");
            photonView.RPC(nameof(Time), RpcTarget.All, TimeScript.time);
        }
    }
    [PunRPC]
    void Time(float time) //③変数+変化を指定
    {
        Debug.Log("True2");
        int times = (int)time;
        text.text = times.ToString();
    }
}
