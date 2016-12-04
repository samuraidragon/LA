using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RisuHPScript : MonoBehaviour {
public int HP = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Hebihead") {
			HP--;
			if (HP <= 0) {
			SceneManager.LoadScene("gameover");
			}

		}
	}
}
