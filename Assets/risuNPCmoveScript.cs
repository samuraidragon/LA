using UnityEngine;
using System.Collections;

public class risuNPCmoveScript : MonoBehaviour {
	public float speed;
	float kinematicUnlock;

	// Use this for initialization
	void Start () {
	GetComponent<Rigidbody>().isKinematic = true;
		kinematicUnlock = 0;

	
	}
	
	// Update is called once per frame
	void Update ()
	{
		kinematicUnlock += Time.deltaTime;
		if (kinematicUnlock > 0.35f) {
			GetComponent<Rigidbody>().isKinematic = false;
		}
	transform.Translate(Vector3.forward * Time.deltaTime * speed);

	}


}
