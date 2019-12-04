using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PhotonManager : Photon.MonoBehaviour
{
    public void ConnectPhoton()
    {
        PhotonNetwork.ConnectUsingSettings("1.0");
    }
    void OnJoinedRoom()
    {
        Debug.Log("PhotonManager OnJoinedRoom");
        SceneManager.LoadScene("MainScene");
    }
    void OnJoinedLobby()
    {
        Debug.Log("PhotonManager OnJoinedLobby");
        GameObject.Find("CreateRoomB").GetComponent<Button>().interactable = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CreateRoom()
    {
        string userName = "ユーザ1";
        string userId = "user1";
        PhotonNetwork.autoCleanUpPlayerObjects = false;
        //カスタムプロパティ
        ExitGames.Client.Photon.Hashtable customProp = new ExitGames.Client.Photon.Hashtable();
        customProp.Add("userName", userName); //ユーザ名
        customProp.Add("userId", userId); //ユーザID
        PhotonNetwork.SetPlayerCustomProperties(customProp);

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.customRoomProperties = customProp;
        //ロビーで見えるルーム情報としてカスタムプロパティのuserName,userIdを使いますよという宣言
        roomOptions.customRoomPropertiesForLobby = new string[] { "userName", "userId" };
        roomOptions.maxPlayers = 2; //部屋の最大人数
        roomOptions.isOpen = true; //入室許可する
        roomOptions.isVisible = true; //ロビーから見えるようにする
        //userIdが名前のルームがなければ作って入室、あれば普通に入室する。
        PhotonNetwork.JoinOrCreateRoom(userId, roomOptions, null);
    }
}
