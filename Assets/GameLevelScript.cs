using UnityEngine;
using System.Collections;

public class GameLevelScript : MonoBehaviour {


[HideInInspector]
public int level;
	// Use this for initialization
	void Start () {
	level = 1;
	}
	
	// Update is called once per frame
	void Update () {
	Debug.Log("level" + level);
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.name == "Level2") {
		level = 2;
		}
		if (other.name == "Level3") {
		level = 3;
		}
		if (other.name == "Level4") {
		level = 4;
		}
		if (other.name == "goal") {
		level = 5;
		}

	}
}
