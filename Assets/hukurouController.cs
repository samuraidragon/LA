using UnityEngine;
using System.Collections;

public class hukurouController : MonoBehaviour {
GameObject Player;
Vector3 random;
float add;
	// Use this for initialization
	void Start () {
	Player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

	transform.Rotate(0,1 * Time.deltaTime * 10 ,0);
	transform.Translate(Vector3.forward * Time.deltaTime * 7);
	}
}
