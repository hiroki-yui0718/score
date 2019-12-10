using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ScoreSync : MonoBehaviourPunCallbacks
{
    public Text text;
    private int score = 0;
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
                photonView.RPC(nameof(Score), RpcTarget.All, CollisionScript.score, InCollisionScript1.score,InCollisionScript2.score,AddChainScript.score);
            }
        

    }
    [PunRPC]
    void Score(int score1,int score2,int score3,int score4)
    {
        Debug.Log("True2");
        score += score1 + score2 + score3 +score4;　//③変数+変化を指定
        text.text = score.ToString();
        CollisionScript.score = 0;  //⑤当たり判定・足し算初期化
        InCollisionScript1.score = 0;
        InCollisionScript2.score = 0;
        AddChainScript.score = 0;
    }
}
