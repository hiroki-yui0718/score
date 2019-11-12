using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{

    
    void Start() { }

    [ClientCallback]
    void Update()
    {
        if (!isLocalPlayer) { return; }
        // Main Cameraの位置の調整
        Vector3 v = transform.position;
        v.z -= 5;
        v.y += 3;
        Camera.main.transform.position = v;
    }

    [ClientCallback]
    void FixedUpdate()
    {
        if (!isLocalPlayer) { return; }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        CmdMoveSphere(x, z);
    }

    // Sphereの移動
    [Command]
    public void CmdMoveSphere(float x, float z)
    {
        Vector3 v = new Vector3(x, 0, z) * 10f; //適当に調整
        GetComponent<Rigidbody>().AddForce(v);
    }


}
