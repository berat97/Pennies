using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Net;

public class SplashScreenScript : MonoBehaviour {

	// Use this for initialization
	public static string result;
	public static string resultPurchases;
	bool requestFullfilled = false;
	public static int numberPennies = 0;

	/// 
	/// 
	/// 
	/// 
	/// 
	/// 
	/// 
	/// <summary>
	/// ADD total sacings here
	/// </summary>
	/// 
	/// 
	/// 
	/// 
	/// 
	/// 
	/// 
	public static float totalSavings = 0;

	void Start()
	{
		requestFullfilled = false;
		string firstRequest = "http://api.reimaginebanking.com/accounts?key=4cbced8b12e6c652a3946f2b1f39bcb5";
		StartCoroutine (getRequest ("http://api.reimaginebanking.com/accounts?key=4cbced8b12e6c652a3946f2b1f39bcb5"));
		string secondRequest = "http://api.reimaginebanking.com/accounts/5a87a1b45eaa612c093b0f18/purchases?key=4cbced8b12e6c652a3946f2b1f39bcb5";
		StartCoroutine (getSecondRequest (secondRequest));
		StartCoroutine (getSavings ("http://api.reimaginebanking.com/accounts/5a8958206514d52c7774b760/?key=4cbced8b12e6c652a3946f2b1f39bcb5"));
		//StartCoroutine (UpdatePenniesAccount ());
		if (!requestFullfilled) {

		}


	}
	IEnumerator getSavings(string s)
	{
		UnityWebRequest request = UnityWebRequest.Get(s);
		yield return request.Send ();
		string text = request.downloadHandler.text;
		if (request.isError) {
			Debug.Log ("An error has occured");
		}
		var listing = JsonConvert.DeserializeObject<Account[]> (result);
		List<string> accountIds = new List<string> ();
		totalSavings = listing [0].balance;
		requestFullfilled = true;
	}
	IEnumerator getRequest(string s)
	{
		UnityWebRequest request = UnityWebRequest.Get(s);
		yield return request.Send ();
		string text = request.downloadHandler.text;
		if (request.isError) {
			Debug.Log ("An error has occured");
		}
		result = text;
		requestFullfilled = true;
	}
	IEnumerator getSecondRequest(string s)
	{
		UnityWebRequest request = UnityWebRequest.Get(s);
		yield return request.Send ();
		string text = request.downloadHandler.text;
		if (request.isError) {
			Debug.Log ("An error has occured");
		}
		Debug.Log (text);
		resultPurchases = text;
		requestFullfilled = true;
	}

	/**IEnumerator UpdatePenniesAccount()
	{
		int score = -1;
		WWWForm form = new WWWForm ();
		form.AddField ("payment_amount", score);
		form.AddField ("status","pending");
		form.AddField ("payee", "dog");
		form.AddField ("nickname", "bob");
		form.AddField ("payment_date", "2018-02-17");
		form.AddField ("recurring_date", score);
		string data = "{\"amount:\" 1,\"medium:\",\"balance:\",\"transaction_date:\",\"2018-02-18\",\"status:\",\"pending\",\"description\",\"testing\"}";

		UnityWebRequest request = UnityWebRequest.Post ("http://api.reimaginebanking.com/accounts/5a8958206514d52c7774b760/deposits?key=4cbced8b12e6c652a3946f2b1f39bcb5", form);
		yield return request.Send();

		if (request.isError) {
			Debug.Log (request.error);
		} else {
			Debug.Log (request.downloadHandler.text);
		}

	}**/
	// Update is called once per frame
	void Update () {
		if (requestFullfilled && Input.anyKeyDown)
		{
			var listing = JsonConvert.DeserializeObject<Account[]> (result);
			List<string> accountIds = new List<string> ();
			for (int i = 0; i < listing.Length; i++) 
			{
				accountIds.Add(listing [i]._id);
				Debug.Log (listing [i]._id);
			}
			var purchases = JsonConvert.DeserializeObject<Purchase[]> (resultPurchases);
			//The account used for testing(add all transactions to that account) 5a....f18
			for (int i = 0; i < purchases.Length; i++) 
			{
				
				Debug.Log (purchases[i].amount);
				if(((decimal)purchases [i].amount % 1) != 0)
				{
				numberPennies +=  (int) ((1.0d - ((double)((decimal)purchases [i].amount % 1))) * 100);
				}
			}
		
			Debug.Log (listing[0].nickname);
			SceneManager.LoadScene(1);
		}

	}

}
