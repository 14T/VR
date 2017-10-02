using UnityEngine;
using System.Collections;

public class PathFollower : MonoBehaviour {
	Node[] pathNode;
	GameObject player;
	//the object who move along the path.
	public float moveSpeed;
	//the speed when moving along the path
	float Timer;
	//default time
	//so i forgot make a current to hold current node
	int CurrentNode;
	//this will hold current node
	static Vector3 CurrentPositionHolder;
	//the vector3 hold Node position

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectsWithTag ("Player")[0];
		pathNode = GetComponentsInChildren<Node> ();
		CheckNode (); 
	
	}

/// <summary>
	/// we will make a function to check current Node and move to it. by save the node position to CurrenPositionHolder
	/// </summary>
	/// 
	void CheckNode () {
		if (CurrentNode < pathNode.Length - 1) {
			Timer = 0;
			CurrentPositionHolder = pathNode [CurrentNode].transform.position;
			// we will hold the currentNode position to CurrenPosHolder.
	
		} else {
			CurrentNode = 0;
			CurrentPositionHolder = pathNode [CurrentNode].transform.position;
		}
	}

	void DrawLine () {
		for (int i = 0; i < pathNode.Length; i++) {
			//we will paint from PathNode[0] to 1 , 1 to 2 and like this to end of Pathnode
			if (i < pathNode.Length - 1) {
				Debug.DrawLine (pathNode [i].transform.position, pathNode [i + 1].transform.position, Color.green);
			} else {
				Debug.DrawLine (pathNode [i].transform.position, pathNode [0].transform.position, Color.green);
			}
		}
	}
	// Update is called once per frame
	void Update () {
		DrawLine ();
//		Debug.Log (CurrentNode);
		float speed;
		speed = moveSpeed / (pathNode [CurrentNode].travelTimeToThisNode * 10);

		Timer += Time.deltaTime * speed;
		//this will make the path moving
		// foreach (GameObject g in player) {
			if (player.transform.position != CurrentPositionHolder) {
				//if player position not equal Node position we will move the player to node
				player.transform.position = Vector3.Lerp (player.transform.position, CurrentPositionHolder, Timer);

			} else {
				if (CurrentNode < pathNode.Length - 1) {
					//if it equal lthe node we will go next node
					CurrentNode++;
					//here 
					CheckNode ();
				}
			}

		// }
	}
}
