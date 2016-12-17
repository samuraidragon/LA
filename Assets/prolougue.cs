using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class prolougue : MonoBehaviour {

	// Use this for initialization
	void Start () {
		((MovieTexture)GetComponent<RawImage>().mainTexture).Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
