using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class CollisionScript : MonoBehaviourPunCallbacks
{

    public Text Score;
    static float kasanTime = 30;
    int count = 1;
    private int score;
    int su;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
}
    public void SendMethod()
    {
        

    }

        // Update is called once per frame
        void Update()
    {
        kasanTime+= Time.deltaTime;
  

    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube") || collision.gameObject.CompareTag("Cube1") || collision.gameObject.CompareTag("Cube2"))
        {
            if (kasanTime > 0 && kasanTime <= 30)
            {
                count++;
                if (photonView.IsMine)
                {
                    PhotonView photonView = GetComponent<PhotonView>();
                    photonView.RPC("addScore50", RpcTarget.All, 50);
                    photonView.RPC("addScore10", RpcTarget.All, 10 * count);
                }
                Score.text = (int.Parse(Score.text) + score).ToString();
                Destroy(collision.gameObject);
                kasanTime = 0;
            }
            else
            {
                if (photonView.IsMine)
                {
                    PhotonView photonView = GetComponent<PhotonView>();
                    photonView.RPC("addScore50", RpcTarget.All, 50);
                }
                Score.text = (int.Parse(Score.text) + score).ToString();
                Destroy(collision.gameObject);
                kasanTime = 0;
            }
            
        }


        Debug.Log("Hit"); // ログを表示する
    }
    [PunRPC]
    void addScore50(int su)
    {
        score += su;
    }
    [PunRPC]
    void addScore10(int su)
    {
        score += su;
    }

}
