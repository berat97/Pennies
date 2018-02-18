using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Camera cam;
	public GameObject coin;
	public Text penniesText;
	public Text savingsText;
	// Use this for initialization
	private float maxWidth;
	void Start () {
		//savingsText.text = "Total Savings:\n" + SplashScreenScript.totalSavings;
		//Debug.Log (SplashScreenScript.result);
		Debug.Log (SplashScreenScript.numberPennies);
		if (cam == null) {
			cam = Camera.main;
		}
		Vector2 upperCorner = new Vector2 (Screen.width, Screen.height);
		Vector2 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		float coinwidth = coin.GetComponent<Renderer> ().bounds.extents.x;
		maxWidth = targetWidth.x - coinwidth;
		StartCoroutine (Spawn ());
		penniesText.text = "Pennies Left:\n" + SplashScreenScript.numberPennies;
	}

	// Update is called once per frame
	IEnumerator Spawn(){
		yield return new WaitForSeconds (2.0f);
		while (SplashScreenScript.numberPennies > 0) {
			Vector2 SpawnPosition = new Vector2 (
				Random.Range (-maxWidth, maxWidth), 
				transform.position.y
			);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (coin, SpawnPosition, spawnRotation);
			yield return new WaitForSeconds (Random.Range (1.0f, 2.0f));
			SplashScreenScript.numberPennies--;
			penniesText.text = "Pennies Left:\n" + SplashScreenScript.numberPennies;
		}

	}
}
