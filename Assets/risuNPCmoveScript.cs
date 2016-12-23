using UnityEngine;
using System.Collections;

public class risuNPCmoveScript : MonoBehaviour {
	public float speed;
	float kinematicUnlock;
	int type;
	// Use this for initialization
	void Start () {
		type = Random.Range (1, 3);
	GetComponent<Rigidbody>().isKinematic = true;
		kinematicUnlock = 0;

	
	}
	
	// Update is called once per frame
	void Update ()
	{
		kinematicUnlock += Time.deltaTime;
		if (kinematicUnlock > 0.35f) {
			GetComponent<Rigidbody> ().isKinematic = false;
		}
		transform.Translate (Vector3.forward * Time.deltaTime * speed);
		if (type == 1) {
			transform.Rotate (0, 1 * Time.deltaTime * 5, 0);
		} else {
			transform.Rotate (0, 1 * Time.deltaTime * -6, 0);
		}
	}

	void OnCollisionEnter (Collision other)
	{
		int rannsuu = Random.Range (1, 3);
		if (rannsuu == 1) {
			transform.rotation *= Quaternion.Euler (0, 30, 0);
		} else {
			transform.rotation *= Quaternion.Euler (0, -20, 0);
		}

		if (other.gameObject.tag == "hukurouhead" || other.gameObject.tag == "hukuroubody" ) {
			Debug.Log("DETH");
			StartCoroutine("deth");

		}
	}

	void OnTriggerEnter (Collider other)
	{

		if (other.gameObject.tag == "Hebihead" && other.transform.parent.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("attack") == true) {
			Debug.Log("DETH");
			StartCoroutine("deth");
			}

		if (other.gameObject.tag == "hebi") {
			
			int rannsuu = Random.Range (1, 3);
		if (rannsuu == 1) {
			transform.rotation *= Quaternion.Euler (0, 20, 0);
				//GetComponent<Rigidbody>().velocity = Vector3.forward * 5;
		} else {
			transform.rotation *= Quaternion.Euler (0, -20, 0);
				GetComponent<Rigidbody>().velocity = Vector3.forward * 3;
		}
			}
		if (other.gameObject.tag == "hukurou") {
			
			int rannsuu = Random.Range (1, 3);
		if (rannsuu == 1) {
			transform.rotation *= Quaternion.Euler (0, 50, 0);
				//GetComponent<Rigidbody>().velocity = Vector3.forward * 2;
		} else {
			transform.rotation *= Quaternion.Euler (0, -20, 0);
				//GetComponent<Rigidbody>().velocity = Vector3.forward * 2;
		}
			}


		}

	
		IEnumerator deth ()
	{
	risuScoreScript.Score -= 1;
	yield return new WaitForSeconds(0.5f);

	Destroy(this.gameObject);
	}



	}



