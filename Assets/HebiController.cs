using UnityEngine;
using System.Collections;

public class HebiController : MonoBehaviour {
GameObject Player;
Animator anim;
//SphereCollider SC;
//	StateMachineBehaviour HebiRunAnim;
	AnimatorStateInfo stateInfo;

	public float height;
	// Use this for initialization
	void Start () {
	Player = GameObject.FindWithTag("Player");
	anim = GetComponent<Animator>();
    stateInfo = this.anim.GetCurrentAnimatorStateInfo(0);
		//SC = GetComponent<SphereCollider> ();
	}
	
	// Update is called once per frame
	void Update ()
	{

		if ((Player.transform.position - this.transform.position).magnitude < 9 && (Player.transform.position - this.transform.position).magnitude > 4) {

		//	SC.center = new Vector3 (0.28f, 0, 2.76f);
			transform.LookAt (Player.transform.position);
			transform.Translate (Vector3.forward * Time.deltaTime);
			anim.SetBool ("move", true);
			anim.SetBool ("attack", false);


		} else if ((Player.transform.position - this.transform.position).magnitude < 4) {
		//	SC.center = new Vector3 (0.28f, 0.21f, 2.76f);
			anim.SetBool ("attack", true);
			anim.SetBool ("move", false);

		} else {
		//	SC.center = new Vector3 (0.28f, 0.21f, 2.76f);
			anim.SetBool ("attack", false);
			anim.SetBool ("move", false);

		}
	//	HebiRunAnim = anim.GetBehaviour <positionUp>();  

		/*if (stateInfo.fullPathHash == Animator.StringToHash ("Base Layer.Run")) {
				GetComponent<SphereCollider> ().center = new Vector3 (0.28f, 0, 2.76f);
				Debug.Log ("run");
			}
			if (stateInfo.fullPathHash == Animator.StringToHash ("Base Layer.Attack")) {
				GetComponent<SphereCollider> ().center = new Vector3 (0.28f, 0.24f, 2.76f);
				Debug.Log ("attack");
			}
			if (stateInfo.fullPathHash == Animator.StringToHash ("Base Layer.Idle")) {
			GetComponent<SphereCollider> ().center = new Vector3 (0.28f, 0.24f, 2.76f);
				Debug.Log ("idle");
			}

			*/
	//	HebiRunAnim.OnStateEnter(anim,stateInfo,1);

   
		
	}

	/*public void up ()
	{
		GetComponent<SphereCollider> ().center = new Vector3 (0.28f, 0, 2.76f);
		Debug.Log("up");
	}

	public void down ()
	{
		GetComponent<SphereCollider> ().center = new Vector3 (0.28f, 0.24f, 2.76f);
	}*/
}
