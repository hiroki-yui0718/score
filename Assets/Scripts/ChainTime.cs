using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    int time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    bool Update()
    {
        time = (int)(30.0f - Time.time);
        if(time > 0)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}
