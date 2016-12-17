using UnityEngine;
using System.Collections;

public class hukurouController : MonoBehaviour {
GameObject Player;
GameObject hukuroumodel;
Vector3 random;
float add;
public Animator anim;

float dir;

bool upflag;

	enum statehukurou{
		fly,kakkuu,attack,up
	}
	statehukurou Status;



	// Use this for initialization
	void Start () {
	Status = statehukurou.fly;
	Player = GameObject.FindWithTag("Player");
		upflag = false;
		hukuroumodel = transform.FindChild("hukurou_ani").gameObject;
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		dir = (Player.transform.position - this.transform.position).magnitude;
	//Debug.Log(dir);

		//Debug.Log(dir);


		transform.Rotate (0, 1 * Time.deltaTime * 10, 0);
		transform.Translate (Vector3.forward * Time.deltaTime * 7);

		if ((Player.transform.position - this.transform.position).magnitude < 20 && (Player.transform.position - this.transform.position).magnitude >= 10 && Status == statehukurou.fly) {
		    Status = statehukurou.kakkuu;
			kakkuu ();

		} else if ((Player.transform.position - this.transform.position).magnitude < 10 && (Player.transform.position - this.transform.position).magnitude >= 2 && Status == statehukurou.kakkuu ) {
			Status = statehukurou.attack;
			attack();

		} else if ((this.transform.position.y - Player.transform.position.y) < 1) {
		    Status = statehukurou.up; 
		   

		} 



		if (Status == statehukurou.up) {
			transform.Translate(Vector3.forward * Time.deltaTime);
			transform.rotation = Quaternion.Euler (-40, 0, 0);

		}
		if (this.transform.position.y > 20) {
			Status = statehukurou.fly;
		}


	}
	void kakkuu ()
	{
		
		//	SC.center = new Vector3 (0.28f, 0, 2.76f)
		transform.LookAt (Player.transform.position);
		transform.Translate (Vector3.forward * Time.deltaTime);
		anim.SetBool ("move", false);
		anim.SetBool ("attack", false);
		anim.SetBool ("kakkuu", true);

	}


		void attack(){
		Debug.Log("attack");
		//hukuroumodel.transform.rotation = Quaternion.Euler(10,hukuroumodel.transform.rotation.y,hukuroumodel.transform.rotation.z);
		//transform.LookAt (Player.transform.position + new Vector3(0,10,0));
		transform.Translate (Vector3.forward* Time.deltaTime);
			anim.SetBool ("attack", true);
			anim.SetBool ("move", false);
			anim.SetBool ("kakkuu", false);


		} 



	
}
