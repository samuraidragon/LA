using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class startanim : MonoBehaviour {
	public Animator anim;

	float time;
	bool countfklag;

	// Use this for initialization
	void Start () {
		time = 0;
		countfklag = false;
		//Time.timeScale = 0;
		Application.CaptureScreenshot("画像の名前.png");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown(0)) {
			anim.SetBool ("start", true);
		}

		if (countfklag == true) {
			time += Time.deltaTime;
			Debug.Log (time);
			if (time > 2) {
				SceneManager.LoadScene ("defalme");
			}
		}

	}
	void OnTriggerStay(Collider other){
		if (other.tag == "Tree") {
			countfklag = true;
			}
		}

}
