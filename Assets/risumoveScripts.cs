using UnityEngine;
using System.Collections;

public class risumoveScripts : MonoBehaviour {
	risuController RisuController;
	GameObject Controller;
	//リスの状態を判断するためのステータスを列挙型にしている
	enum state{
		ground,tree,branch
	}
	state Status;

	bool FloatingFlag;  //リスが空中に浮いているかを判断するためのフラグ
	float FloatingCount; //リスが空中に浮いている時の時間


	void Start () {
		Controller = GameObject.Find ("GameControllers");
		RisuController = Controller.GetComponent<risuController> ();
		Cursor.visible = false;  //ゲームスタート時にカーソルを非表示にする
		Status = state.ground; 
		FloatingFlag = false;
		FloatingCount = 0f;
	}
	
	// Update is called once per frame
	void Update ()
	{

		Debug.Log (Status);
		Debug.Log (FloatingFlag);
		Debug.Log (FloatingCount);
		//リスが歩くためのメソッド呼び出し
		RisuController.move (); 
	
		//リスが走るためのメソッド呼び出し
		if (Input.GetKey (KeyCode.LeftShift)) {
			RisuController.dash ();
		}

		//リスが空中にいるときの時間を計測する（すぐに視点が切り替わるのを防ぐため）
		if (FloatingFlag == true) {
			FloatingCount += Time.deltaTime;
			if (FloatingCount > 1f) {
				RisuController.GroundModeStart(); //地上にいる時の1フレーム目の処理メソッド
				Status = state.ground;
				FloatingFlag = false; //リスが空中にいる時間をリセット
				FloatingCount = 0f;
			}
		}


		//地上にいる時のメソッド呼び出し
		if (Status == state.ground)
			RisuController.GroundModeUpdate ();	

		//幹にいる時のメソッド呼び出し
		if (Status == state.tree)
			RisuController.TreeModeUpdate ();	

		//枝の上にいる時のメソッド呼び出し
		if (Status == state.branch)
			RisuController.BranchModeUpdate ();	
		



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

	void OnCollisionExit(Collision other){
		if (other.gameObject.tag == ("Tree")) {
			FloatingFlag = true; //リスが空中にいる時間を計測開始
			FloatingCount = 0f;
		}

		//枝の上にいる1フレーム目
		if (other.gameObject.tag == ("Branch")) {
			FloatingFlag = true; //リスが空中にいる時間を計測開始
			FloatingCount = 0f;
		}


	}
}
