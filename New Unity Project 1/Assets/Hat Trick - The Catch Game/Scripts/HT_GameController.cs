using UnityEngine;
using System.Collections;

public class HT_GameController : MonoBehaviour {
	
	public Camera cam;
	public GameObject bowlingBall;
	public static int timeLeft;
	public GUIText timerText;
	public GameObject gameOverText;
	public GameObject restartButton;
	public GameObject splashScreen;
	public GameObject startButton;
	public HT_HatController hatController;
	
	private float maxWidth;
	public float spawnTime = 3f;
	private bool counting;
	
	// Use this for initialization
	void Start () {
		if (cam == null) {
			cam = Camera.main;
		}
		//Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
		//Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		//float ballWidth = balls[0].GetComponent<Renderer>().bounds.extents.x;
		//maxWidth = targetWidth.x - ballWidth;
		//timerText.text = "COINS LEFT:\n" + timeLeft;
		InvokeRepeating("spawnBall", spawnTime, spawnTime);
	}

	void spawnBall()
	{
		var newBall = GameObject.Instantiate(bowlingBall);
	}

	public void StartGame () {
		splashScreen.SetActive (false);
		startButton.SetActive (false);
		hatController.ToggleControl (true);
	}


	}

