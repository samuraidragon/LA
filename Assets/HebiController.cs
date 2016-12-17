using UnityEngine;
using System.Collections;

public class HebiController : MonoBehaviour {
GameObject Player;
Animator anim;
//SphereCollider SC;
//	StateMachineBehaviour HebiRunAnim;
	AnimatorStateInfo stateInfo;

	public float height;

	bool backflag;


	// Use this for initialization
	void Start () {
	Player = GameObject.FindWithTag("Player");
	anim = GetComponent<Animator>();
    stateInfo = this.anim.GetCurrentAnimatorStateInfo(0);
	bool backflag = false; 
		//SC = GetComponent<SphereCollider> ();
	}
	
	// Update is called once per frame
	void Update ()
	{


		if ((Player.transform.position - this.transform.position).magnitude < 9 && (Player.transform.position - this.transform.position).magnitude > 3 && backflag == false) {
			//	SC.center = new Vector3 (0.28f, 0, 2.76f)
			transform.LookAt (Player.transform.position);
			transform.Translate (Vector3.forward * Time.deltaTime);
			anim.SetBool ("move", true);
			anim.SetBool ("attack", false);



		} else if ((Player.transform.position - this.transform.position).magnitude < 3 && (Player.transform.position - this.transform.position).magnitude > 1.7f && backflag == false) {
			//	SC.center = new Vector3 (0.28f, 0.21f, 2.76f);
			transform.LookAt (Player.transform.position + new Vector3 (0.2f, 0, 0));
			anim.SetBool ("attack", true);
			anim.SetBool ("move", false);


		} else if ((Player.transform.position - this.transform.position).magnitude < 1.7f) {
			//GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePositionY;
			StartCoroutine ("backstep");
		} else {
			
		//	SC.center = new Vector3 (0.28f, 0.21f, 2.76f);
			anim.SetBool ("attack", false);
			anim.SetBool ("move", true);
			transform.Rotate (0, 1 * Time.deltaTime * 10, 0);
			transform.Translate (Vector3.forward * Time.deltaTime * 2);


		}
   
		
	}
	IEnumerator backstep ()
	{
		
		backflag = true;
		if (backflag == true) {
			transform.rotation = transform.rotation * Quaternion.Euler(12,180,0);
			transform.Translate (Vector3.forward * Time.deltaTime * 150);
			//GetComponent<Rigidbody>().velocity += transform.forward * 7;
			GetComponent<Rigidbody>().isKinematic = true;
			anim.Play(Animator.StringToHash("dash"));
			yield return new WaitForSeconds(0.2f);
			GetComponent<Rigidbody>().isKinematic = false;
			yield return new WaitForSeconds(0.4f);
			transform.rotation = transform.rotation * Quaternion.Euler(0,180,0);
			//GetComponent<Rigidbody>().isKinematic = false;

			backflag = false;
		}

	}


}
