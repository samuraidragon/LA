using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class risuScoreScript : MonoBehaviour {
	public static float Score;
	int hold;
	public int Limit;
	public int goal;
	public Text ScoreText;
	public GameObject risuNPC;

	public Sprite [] risuface;

	public GameObject hierarky;
	public GameObject holdUI;

	// Use this for initialization
	void Start () {
		//holdUI.GetComponent<Image>().material.mainTexture = risuface[0];
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (hold == 0) {
			holdUI.GetComponent<Image> ().sprite = risuface [0];
		}else if (hold == 1) {
			holdUI.GetComponent<Image> ().sprite = risuface [1];
		}else if (hold >= 2 && hold <= 3) {
			holdUI.GetComponent<Image> ().sprite = risuface [2];
	}else if (hold >= 4 && hold <= 5) {
			holdUI.GetComponent<Image> ().sprite = risuface [3];
	}else if (hold >= 6 && hold <= 7) {
			holdUI.GetComponent<Image> ().sprite = risuface [4];
	}else if (hold == Limit) {
			holdUI.GetComponent<Image> ().sprite = risuface [5];
		}
		
		hierarky.GetComponent<RectTransform>().position = new Vector3 (hierarky.GetComponent<RectTransform>().position.x, Score * 5f ,hierarky.GetComponent<RectTransform>().position.z);

		if (Score >= goal) {
		SceneManager.LoadScene("clear");
		}

		ScoreText.text = "Score:" + Score.ToString() + "/" + goal.ToString();
	}
	void OnCollisionEnter (Collision other)
	{

		if (other.gameObject.tag == "Almond") {
			GameObject A = other.gameObject;
			if (hold < Limit) {
				StartCoroutine(AlmondDestroy(A));
			}


		}
		if (other.gameObject.tag == "Nest") {
			StartCoroutine(Nest(other.gameObject));


		}
	}
	private IEnumerator AlmondDestroy (GameObject A)
	{
		yield return new WaitForSeconds (0.01f);
		Destroy (A.gameObject);
		hold += 2;
		if (hold > Limit) {
		hold = Limit;
		}

	}
	private IEnumerator Nest (GameObject N)
	{
		
		int stock = 0;
		stock = hold;
		yield return new WaitForSeconds (0.01f);
		hold = 0;

		GetComponent<risumoveScripts> ().enabled = false;
		yield return new WaitForSeconds (1f);
		GetComponent<risumoveScripts> ().enabled = true;

		//Score += stock;
		for (int s = 0; s < stock; s++) {
			Instantiate (risuNPC, N.transform.position, Quaternion.Euler (0, Random.Range (0, 360), 0));
			Score ++;
			yield return new WaitForSeconds (0.5f);

		}

		yield return new WaitForSeconds(0.01f);
			stock = 0;

		yield return new WaitForSeconds(0.01f);

	
	
	}
}
