using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class risuScoreScript : MonoBehaviour {
	public static int Score;
	int hold;
	public int Limit;
	public int goal;
	public Text HoldText;
	public Text ScoreText;
	public GameObject risuNPC;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{


		if (Score >= goal) {
		SceneManager.LoadScene("clear");
		}
		HoldText.text = "Hold:" + hold.ToString() + "/" + Limit.ToString();
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

		GetComponent<risumoveScripts> ().enabled = false;
		yield return new WaitForSeconds (1f);
		GetComponent<risumoveScripts> ().enabled = true;

		Score += stock;
		for (int s = 0; s < stock; s++) {
			Instantiate (risuNPC, N.transform.position, Quaternion.Euler (0, Random.Range (0, 360), 0));
			Instantiate (risuNPC, N.transform.position, Quaternion.Euler (0, Random.Range (0, 360), 0));
			Instantiate (risuNPC, N.transform.position, Quaternion.Euler (0, Random.Range (0, 360), 0));

			Instantiate (risuNPC, N.transform.position, Quaternion.Euler (0, Random.Range (0, 360), 0));
			Instantiate (risuNPC, N.transform.position, Quaternion.Euler (0, Random.Range (0, 360), 0));


		}

		yield return new WaitForSeconds(0.01f);
			stock = 0;
			hold = 0;
		yield return new WaitForSeconds(0.01f);

	
	
	}
}
