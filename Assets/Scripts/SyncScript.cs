using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncScript : Photon.MonoBehaviour
{
    public int hensu1 = 0;
    public GameObject Text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            //データの送信
            stream.SendNext(hensu1);
        }
        else
        {
            //データの受信
            this.hensu1 = (int)stream.ReceiveNext();
        }
    }
}
