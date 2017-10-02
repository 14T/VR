using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour {

	public float travelTimeToThisNode;
	public float haltTime;

	// Use this for initialization
	void Start () {
	
		if (travelTimeToThisNode == 0) {
			travelTimeToThisNode = 2.0f;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
