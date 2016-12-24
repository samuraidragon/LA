using UnityEngine;
using System.Collections;

public class risumaeasioto : MonoBehaviour {
public AudioSource asioto;
	public AudioSource asiototree;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Ground") {
			asioto.Play ();

		}
		if (other.tag == "Tree" || other.tag == "Branch") {
			asiototree.Play ();
		}
	}
}
