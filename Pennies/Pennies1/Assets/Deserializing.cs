using System.Collections;
using System.Collections.Generic;

public class Deserializing{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

public class Account
{
	public string _id { get; set; }
	public string type { get; set; }
	public string nickname { get; set; }
	public float rewards { get; set; }
	public float balance { get; set; }
	public string customer_id { get; set; }
}

public class Purchase
{
	public string _id { get ; set; }
	public string merchant_id { get ; set; }
	public string medium{ get ; set; }
	public string purchase_date{ get ; set; }
	public double amount{ get ; set; }
	public string status{ get ; set; }
	public string description{ get ; set; }
	public string type{ get ; set; }
	public string payer_id{ get ; set; }
	public string payee_id{ get ; set; }
}
