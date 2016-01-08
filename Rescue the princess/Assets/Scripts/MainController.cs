using UnityEngine;
using System.Collections;

public class MainController : MonoBehaviour {

	// Use this for initialization
	void Star()
	{
		#region Check Something
		#endregion
		
		#region Build Base Object  (断线重连)
		#endregion
		
		
		#region Guide Story1
		#endregion
		
		#region LoginPanel
		#endregion
		
		#region MainPanel
		
		#region  Top left
		//        GameObject gm8 = Instantiate(Resources.Load("UI/MainUICtroler/TopLeft/Panel")) as GameObject;
		//        Transform tf8 = gm8.transform;
		//
		//        tf8.parent = this.transform.parent.parent.Find("TopLeft");
		//        tf8.localPosition = new Vector3(0f, 0f, 0f);
		//        tf8.localScale = Vector3.one;
		//        tf8.localRotation = Quaternion.identity;
		
		// push in to panels
		//MainUICtroler.instance.panels.Add(tf8.Find("mengpaixinxiUI").gameObject);
		
		//MainUICtroler.instance.mengpaixinxiUI = tf8.Find("mengpaixinxiUI").gameObject;
		//        setButtonMessage(tf8.Find("mengpaixinxiUI"), GUIManage.Instance.gameObject, "RequestFirstUI");  // call fun 1
		#endregion
		
		#region  Top right // current empty.
		#endregion
		
		#region  Center
		#endregion
		
		#region Bottom right
		#endregion
		
		#region Bottom left
		#endregion
		
		#endregion
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	static StoreConfig sc = new StoreConfig();
	void OnEnable()
	{
		//sc.ReadFile ();
	}
	void OnDisable()
	{
		//sc.WriteFile ();
	}
}
