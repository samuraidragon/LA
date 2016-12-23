using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class RisuHPScript : MonoBehaviour {
public float MAXHP = 5;
public float HP;
AnimatorStateInfo hebianim; 

public GameObject HPgage;


	// Use this for initialization
	void Start () {
	HP = MAXHP;


	}
	
	// Update is called once per frame
	void Update () {

		HPgage.GetComponent<Image>().fillAmount = HP / MAXHP;

	}
	void OnTriggerEnter (Collider other)
	{

		if (other.gameObject.tag == "Hebihead" && other.transform.parent.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack") == true) {
			HP--;
			if (HP <= 0) {
			//Destroy(this.gameObject);
			SceneManager.LoadScene("gameover");
			}

		}

	}

	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.tag == "hukurouhead" || other.gameObject.tag == "hukuroubody" ) {
			HP -= 2;
			if (HP <= 0) {
				//Destroy(this.gameObject);
				SceneManager.LoadScene("gameover");
			}

		}
	}
}
