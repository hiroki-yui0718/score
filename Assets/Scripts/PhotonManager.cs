using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PhotonManager : Photon.MonoBehaviour
{
    PhotonNetwork.ConnectUsingSettings("v1.0");

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnJoinedLobby()
    {
        Debug.Log("PhotonManager OnJoinedLobby");
    }
}
