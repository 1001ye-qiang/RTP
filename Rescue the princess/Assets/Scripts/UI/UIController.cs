using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {

	static UIController Inst;
	void Awake()
	{
		Inst = this;
	}
	// Use this for initialization
	void Start () {
		uiCamera = transform.parent.Find ("Camera");
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	Transform uiCamera;

	public void SharkeCamera()
	{
		if (uiCamera != null) {
		
		}
	}



}
