using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ScoreSync : MonoBehaviourPunCallbacks, IPunObservable
{
    public Text TimeText;
    public Text Score;
    private float hensu;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.score = int.Parse(Score.text);
    }
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(score);

        }
        // オーナー以外の場合
        else
        {
            this.score = (int)stream.ReceiveNext();

        }
    }
}
