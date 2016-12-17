using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RisuHPScript : MonoBehaviour {
public int HP = 1;
AnimatorStateInfo hebianim; 
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
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
}
