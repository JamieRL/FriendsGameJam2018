using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {
    private bool hasPower;

	// Use this for initialization
	void Start () {
        hasPower = false;
        // Set to the off animation
    }

    // Update is called once per frame
    public void powerOn() {
        hasPower = true;
        // Set to the on animation
	}

    public bool isPowered()
    {
        return hasPower;
    }
}
