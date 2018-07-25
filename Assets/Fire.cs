using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {
    [SerializeField] Vector3 power;

    bool fire;

    // Update is called once per frame
    void Update() {
        if (!fire && !Record.Recording && Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().AddForce(power);
            Record.StartRecord();
            fire = true;
        }

        if (fire && Record.Recording == false && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Play Record");

        }
    }
}
