using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision c)
	{
		Debug.Log (c.gameObject.name + " collised " + gameObject.name);
		//if(c.gameObject.name == "fruit")
	}
}
