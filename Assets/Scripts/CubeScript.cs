using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CubeScript : Photon.MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    private GameObject cube;
    //ルーム入室した時に呼ばれるコールバックメソッド
    void OnJoinedRoom()
    {
        Debug.Log("PhotonManager OnJoinedRoom");
        GameObject.Find("StatusText").GetComponent<Text>().text
           = "OnJoinedRoom";

        Vector3 initPos = new Vector3(0, 1, 0);
        cube = PhotonNetwork.Instantiate("Sphere", initPos,
                              Quaternion.Euler(Vector3.zero), 0);

    }
}
