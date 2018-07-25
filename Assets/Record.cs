using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.Animations;

public class Record : MonoBehaviour {
    public AnimationClip clip;

    public static bool Recording { get; private set; }
    static float RecordTime = 5f;
    static float StartTime = 0;
    GameObjectRecorder recorder;

	// Use this for initialization
	void Start () {
        recorder = new GameObjectRecorder(gameObject);
        recorder.BindComponent<Transform>(gameObject, true);
        clip.ClearCurves();
	}
	
    public static void StartRecord()
    {
        Debug.Log("Start Record");
        Recording = true;
        StartTime = Time.time;
    }

	// Update is called once per frame
	void Update () {
        if (Recording)
        {
            recorder.TakeSnapshot(Time.deltaTime);

            if (Time.time - StartTime > RecordTime)
            {
                Debug.Log("End Record");
                Recording = false;
                recorder.SaveToClip(clip);
                GetComponent<Animator>().speed = 0.5f;
            }
        }
    }
}
