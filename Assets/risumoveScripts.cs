using UnityEngine;
using System.Collections;
public class risumoveScripts : MonoBehaviour {
	risuController RisuController;
	GameObject Controller;
	public GameObject jumpicon;
	float speedfly;
	Vector3 warppointpos;

	bool warpflag;


	//リスの状態を判断するためのステータスを列挙型にしている
	public enum state{
		ground,tree,branch
	}
	public state Status;

	bool FloatingFlag;  //リスが空中に浮いているかを判断するためのフラグ
	float FloatingCount; //リスが空中に浮いている時の時間
	bool JumpLimltFlag; //jumpを一回に制限するためのフラグ


	void Start () {
		Controller = GameObject.Find ("GameControllers");
		RisuController = Controller.GetComponent<risuController> ();
	//	Cursor.visible = false;  //ゲームスタート時にカーソルを非表示にする
		Status = state.ground; 
		FloatingFlag = false;
		FloatingCount = 0f;

		speedfly = 0;

		warpflag = false;

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetMouseButtonDown (0)) {
			RisuController.attack ();
		}

//		Debug.Log(Status);
	
		if(warpflag == true){
			
			speedfly += Time.deltaTime * Mathf.Pow(5,2);
				transform.LookAt (warppointpos);
			transform.Translate (Vector3.forward * Time.deltaTime * speedfly);
			    RisuController.anim.Play(Animator.StringToHash("attack"));
				}
		if ((warppointpos - transform.position).magnitude <= 0.1f) {
			
			warpflag = false;
			speedfly = 0;
		}


		//リスが歩くためのメソッド呼び出し
		RisuController.move (); 
	
		//リスが走るためのメソッド呼び出し
		if (Input.GetKey (KeyCode.LeftShift)) {
			RisuController.dash ();
		}
		if (Input.GetKeyDown (KeyCode.Space) && Input.GetAxis ("Vertical") > 0 && JumpLimltFlag == false) {
			RisuController.jump ();
			JumpLimltFlag = true; //jumpを一回に制限するためのフラグをONに（jumpできないように制限）
		}

		//リスが空中にいるときの時間を計測する（すぐに視点が切り替わるのを防ぐため）
		if (FloatingFlag == true) {
			FloatingCount += Time.deltaTime;
			RisuController.anim.SetBool("flow",true); //空中アニメーション　ON
			if (FloatingCount > 0.2f) {
				RisuController.GroundModeStart (); //地上にいる時の1フレーム目の処理メソッド
				Status = state.ground;
				FloatingFlag = false; //リスが空中にいる時間をリセット
				FloatingCount = 0f;
			}
		}


		//地上にいる時のメソッド呼び出し
		if (Status == state.ground)
			RisuController.GroundModeUpdate ();	

		//幹にいる時のメソッド呼び出し
		if (Status == state.tree) {
			RisuController.TreeModeUpdate ();
		}

		//枝の上にいる時のメソッド呼び出し
		if (Status == state.branch) {
			RisuController.BranchModeUpdate ();	

		}
		



	}

	void OnCollisionEnter(Collision other){
		
		//幹にいる時の1フレーム目
		if(other.gameObject.tag == ("Tree") && Status != state.tree && FloatingFlag == false){
			RisuController.TreeModeStart(); //幹にいる1フレーム目処理メソッド
			Status = state.tree;
			FloatingFlag = false;  //リスが空中にいる時間をリセット
			FloatingCount = 0f;
		}

		//枝の上にいる1フレーム目
		if(other.gameObject.tag == ("Branch") && Status != state.branch  && FloatingFlag == false){
			RisuController.BranchModeStart(); //枝の上にいる1フレーム目処理メソッド
			Status = state.branch;
			FloatingFlag = false; //リスが空中にいる時間をリセット
			FloatingCount = 0f;
		}
	}


	void OnCollisionStay(Collision other){
		
		//幹にいる間ずっと
		if(other.gameObject.tag == ("Tree")){

			FloatingFlag = false;  //リスが空中にいる時間をリセット
			RisuController.anim.SetBool("flow",false); //空中アニメーション　OFF
			FloatingCount = 0f;


		}

		//枝の上にいる間ずっと
		if(other.gameObject.tag == ("Branch")){

			//リスが空中にいる時間をリセット
			if(FloatingFlag != false)
			FloatingFlag = false; 
			FloatingCount = 0f;
			if(RisuController.anim.GetBool("flow") != false)
			RisuController.anim.SetBool("flow",false); //空中アニメーション　OFF

		}

		//地面の上にいる間ずっと
		if(other.gameObject.tag == ("Ground")){

			//jumpを一回に制限するためのフラグをオフに（jumpできるようにリセット）
			if(JumpLimltFlag != false)
			JumpLimltFlag = false; 

			//空中アニメーション　OFF
			if(RisuController.anim.GetBool("flow") != false)
			RisuController.anim.SetBool("flow",false);


		}
	}






	void OnCollisionExit(Collision other){
		if (other.gameObject.tag == ("Tree")) {
			FloatingFlag = true; //リスが空中にいる時間を計測開始
			RisuController.anim.SetBool("flow",true); //空中アニメーション　ON
			FloatingCount = 0f;
		}

		//枝の上にいる1フレーム目
		if (other.gameObject.tag == ("Branch")) {
			FloatingFlag = true; //リスが空中にいる時間を計測開始
			RisuController.anim.SetBool("flow",true); //空中アニメーション　ON
			FloatingCount = 0f;
		}


	}

	void OnTriggerStay (Collider other)
	{
		if (other.gameObject.tag == "warp" && Status == state.tree) {
			
			warppointpos = other.gameObject.transform.position;
			jumpicon.gameObject.SetActive (true);

			if (Input.GetKeyDown (KeyCode.Space) ) {
				warpflag = true;
			}
					
			}
		}
	

	void OnTriggerExit (Collider other)
	{

		if (other.gameObject.tag == "warp") {
			jumpicon.gameObject.SetActive(false);
			warpflag = false;

		}
	}
}
