using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staticValue : MonoBehaviour {
    static public int levelValue = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Plus()
    {
        levelValue += 1;
        Debug.Log(levelValue);
    }
}
