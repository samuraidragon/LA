using UnityEngine;
using System.Collections;

public class risuController : MonoBehaviour {
	public GameObject neck; 
	public GameObject risu;
	public float jumppowr = 1;
	Vector3 mousepos;
	float rotate_x;
	float rotate_y;
	public Animator anim;



	// Use this for initialization
	void Start () {
//		if (GameObject.Find ("risu") != null) { //リスが削除されていないかをチェック
//			risu = GameObject.Find ("risu");
//			neck = GameObject.Find ("risu/kubi");
//		
//		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	//地上にいる時の1フレーム目
	public void GroundModeStart(){							
		risu.GetComponent<Rigidbody> ().useGravity = true;		 //重力をいれる
		risu.GetComponent<Rigidbody> ().isKinematic = false;		 //木から離れるようになる
		risu.transform.eulerAngles =  new Vector3(0, 0, 0);	//視点を前に（体を横にする）
		anim.SetBool("tree",false); //木にへばりついているアニメーション　OFF（立っているアニメーション　ON）

	}

	//地上にいる時ずっと
	public void GroundModeUpdate(){
		rotate_x = Input.GetAxis("Mouse Y");
		rotate_y = Input.GetAxis("Mouse X");
		risu.transform.rotation = risu.transform.rotation *  Quaternion.Euler (0,rotate_y,0);
		neck.transform.rotation = neck.transform.rotation * Quaternion.Euler(-rotate_x,0,0);
		anim.SetBool("tree",false); //木にへばりついているアニメーション　OFF（立っているアニメーション　ON）
	}

	//幹にいる時の1フレーム目
	public void TreeModeStart(){   
		
		risu = GameObject.Find ("risu");
		risu.GetComponent<Rigidbody> ().isKinematic = true;       //木にくっつく
		risu.GetComponent<Rigidbody> ().useGravity = false;		 //重力をなくす
		risu.transform.rotation = risu.transform.rotation * Quaternion.Euler (-80, 0, 0);

	}

	//幹にいる時ずっと
	public void TreeModeUpdate ()
	{   
		rotate_x = Input.GetAxis ("Mouse Y");
		rotate_y = Input.GetAxis ("Mouse X");
		risu.transform.rotation = risu.transform.rotation * Quaternion.Euler (0, rotate_y, 0);
		neck.transform.rotation = neck.transform.rotation * Quaternion.Euler (-rotate_x, 0, 0);
		anim.SetBool("tree",true); //木にへばりついているアニメーション　ON
		risu.GetComponent<Rigidbody> ().isKinematic = true;       //木にくっつく
		if (Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") != 0) {
			risu.GetComponent<Rigidbody> ().isKinematic = false;

		} 
	}

	//枝の上にいる1フレーム目
	public void BranchModeStart(){   
		risu.GetComponent<Rigidbody> ().isKinematic = true;       //木にくっつく
		risu.GetComponent<Rigidbody> ().useGravity = false;		 //重力をなくす
		risu.transform.eulerAngles =  new Vector3(0, 0, 0);	//視点を前に（体を横にする）
		anim.SetBool("tree",false); //木にへばりついているアニメーション　OFF（立っているアニメーション　ON）

	}

	//枝の上にいるあいだずっと
	public void BranchModeUpdate ()
	{   
		rotate_x = Input.GetAxis ("Mouse Y");
		rotate_y = Input.GetAxis ("Mouse X");
		risu.transform.rotation = risu.transform.rotation * Quaternion.Euler (0, rotate_y, 0);
		neck.transform.rotation = neck.transform.rotation * Quaternion.Euler (-rotate_x, 0, 0);
		risu.GetComponent<Rigidbody> ().isKinematic = true;       //木にくっつく
		if (Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") != 0) {
			risu.GetComponent<Rigidbody> ().isKinematic = false;
		} 
	}



	public void move () //リスの基本の動き
	{

		float dx = Input.GetAxis ("Horizontal");
		float dy = Input.GetAxis ("Vertical");
		if (dy > 0) {
			risu.transform.Translate (dx * Time.deltaTime * 2, 0, dy * Time.deltaTime * 2);
		}
		anim.SetFloat("speed",dy); //アニメーションのspeedパラメーターに VerticalAxisを割り当てる
		anim.SetBool("dash",false);//ダッシュアニメーション　OFF
	}

	public void dash () //リスのダッシュ
	{
		float dx = Input.GetAxis ("Horizontal");
		float dy = Input.GetAxis ("Vertical");

		if (dy > 0) {
		risu.transform.Translate (dx * Time.deltaTime * 2 * 2 ,0, dy * Time.deltaTime * 2 * 2);
		}
		anim.SetBool("dash",true);//ダッシュアニメーション　ON
	}

	public void jump(){
	risu.GetComponent<Rigidbody>().velocity = Vector3.up * jumppowr;

	}

	public void attack ()
	{

		anim.Play(Animator.StringToHash("attack"));
		risu.GetComponent<Rigidbody>().velocity += risu.transform.forward * 3;
		risu.GetComponent<Rigidbody>().velocity += risu.transform.up * 2;

	}
}
