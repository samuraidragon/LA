﻿using UnityEngine;
using System.Collections;

public class hukurouController : MonoBehaviour {
GameObject Player;
GameObject hukuroumodel;
public GameObject risunpc;

Vector3 random;
float add;
public Animator anim;



float dir;

bool upflag;
bool attacknpcflag;
	enum statehukurou{
		fly,kakkuu,attack,up
	}
	statehukurou Statusf;



	// Use this for initialization
	void Start () {
		 
		 attacknpcflag = false;
	Statusf = statehukurou.fly;
	Player = GameObject.FindWithTag("Player");

		upflag = false;
		hukuroumodel = transform.FindChild("hukurou_ani").gameObject;
	
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (risunpc != null) {
			
		}
		dir = (Player.transform.position - this.transform.position).magnitude;

		if (Statusf == statehukurou.fly)
			fly ();
		if (Statusf == statehukurou.kakkuu)
			kakkuu ();
		if (Statusf == statehukurou.attack)
			attack ();
		if (Statusf == statehukurou.up) {
			transform.Translate (Vector3.forward * Time.deltaTime * 7);
			transform.rotation = Quaternion.Euler (-40, 0, 0);
		}


		if ((Player.transform.position - this.transform.position).magnitude < 13 && (Player.transform.position - this.transform.position).magnitude >= 4 && Statusf == statehukurou.fly) {
			Statusf = statehukurou.kakkuu;
		} else if ((Player.transform.position - this.transform.position).magnitude < 4 && (Player.transform.position - this.transform.position).magnitude >= 2 && Statusf == statehukurou.kakkuu) {
			Statusf = statehukurou.attack;
		} else if ((this.transform.position.y - Player.transform.position.y < 0.5)) {
			Statusf = statehukurou.up; 
		} 
			
		if (this.transform.position.y > 12 && Statusf == statehukurou.up) {
			transform.rotation = Quaternion.Euler (0, 180, 0);
			Statusf = statehukurou.fly;
		}

		if (attacknpcflag == true && risunpc != null) {
			
			if ((risunpc.transform.position - this.transform.position).magnitude >= 4 && Statusf == statehukurou.fly ) {
				Statusf = statehukurou.kakkuu;
			}else if ((risunpc.transform.position - this.transform.position).magnitude < 4 && (risunpc.transform.position - this.transform.position).magnitude >= 2 && Statusf == statehukurou.kakkuu) {
			Statusf = statehukurou.attack;
		   } else if ((this.transform.position.y - risunpc.gameObject.transform.position.y < 0.5f)) {
					Statusf = statehukurou.up; 
				} 
				
				if (this.transform.position.y > 12 && Statusf == statehukurou.up) {
					transform.rotation = Quaternion.Euler (0, 180, 0);
					Statusf = statehukurou.fly;
				}
			}
		

	}
	void kakkuu ()
	{
		
		//	SC.center = new Vector3 (0.28f, 0, 2.76f)
		if (attacknpcflag == false) {
			
			transform.LookAt (Player.transform.position + new Vector3 (0, 0, 1));
			transform.Translate (Vector3.forward * Time.deltaTime * 10);
			anim.SetBool ("move", false);
			anim.SetBool ("attack", false);
			anim.SetBool ("kakkuu", true);
		} else {
			if (risunpc != null) {
				transform.LookAt (risunpc.gameObject.transform.position + new Vector3(0,0,1));
				transform.Translate (Vector3.forward * Time.deltaTime * 10);
				anim.SetBool ("move", false);
				anim.SetBool ("attack", false);
				anim.SetBool ("kakkuu", true);
			}
		}

	}


		void attack ()
	{
		if (attacknpcflag == false) {
			//hukuroumodel.transform.rotation = Quaternion.Euler(10,hukuroumodel.transform.rotation.y,hukuroumodel.transform.rotation.z);
			transform.LookAt (Player.transform.position + new Vector3 (0, 0, 0.1f));
			transform.Translate (Vector3.forward * Time.deltaTime * 8);
			anim.SetBool ("attack", true);
			anim.SetBool ("move", false);
			anim.SetBool ("kakkuu", false);
		} else {
			if (risunpc != null) {
				transform.LookAt (risunpc.gameObject.transform.position + new Vector3 (0, 0, 0.5f));
				transform.Translate (Vector3.forward * Time.deltaTime * 8);
				anim.SetBool ("move", false);
				anim.SetBool ("attack", true);
				anim.SetBool ("kakkuu", false);
			}

		} 
	}
	void fly(){

		transform.Rotate (0, 1 * Time.deltaTime * 13, 0);
		transform.Translate (Vector3.forward * Time.deltaTime * 6);

		anim.SetBool ("attack", false);
		anim.SetBool ("move", true);
		anim.SetBool ("kakkuu", false);
	//	risunpc =null;


	} 

	void OnTriggerStay (Collider other)
	{
		if (other.tag == "risuNPC" && Statusf == statehukurou.fly) {
		risunpc = other.gameObject;
		attacknpcflag = true;
		}
	}




	
}
