using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RisuHPScript : MonoBehaviour {
public int HP = 5;
AnimatorStateInfo hebianim; 
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("HP:" + HP);
	}
	void OnTriggerEnter (Collider other)
	{

		if (other.gameObject.tag == "Hebihead" && other.transform.parent.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack") == true) {
			HP--;
			if (HP <= 0) {
			Destroy(this.gameObject);
			SceneManager.LoadScene("gameover");
			}

		}

	}

	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.tag == "hukurouhead" || other.gameObject.tag == "hukuroubody" ) {
			HP -= 2;
			if (HP <= 0) {
				Destroy(this.gameObject);
				SceneManager.LoadScene("gameover");
			}

		}
	}
}
