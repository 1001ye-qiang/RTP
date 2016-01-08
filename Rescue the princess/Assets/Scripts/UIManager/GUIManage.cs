using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

// Code Enterance, must init first.
public class GUIManage : MonoBehaviour
{
    private static GUIManage Inst;
    public static GUIManage Instance
    {
		get  { return Inst; }
    }
    void Awake()
    {
		Inst = this;
    }

	// whos create who destory.
//	Transform rootTransform = null;
//	void remindMe()
//	{
//		UIRoot root = NGUITools.FindInParents<UIRoot>(this.gameObject);
//		rootTransform = root.transform;
//	}
	
	static GameObject objMainUI = null;
	static Stack<GameObject> WinStack = new Stack<GameObject> ();
	private static void WinStackClear()
	{
		while (WinStack.Count > 0) {
			NGUITools.Destroy(WinStack.Pop());
		}
	}
	public static void ShowMainUI(bool Show = true)
	{
		if (objMainUI != null) {
			objMainUI.SetActive(Show);
		}
	}
	/// <summary>
	/// 请求加载一级UI的时候都走这个方法,销毁其他界面
	/// </summary>
	public static GameObject RequestFirstUI(string uiName, Dictionary data = null)
	{
		WinStackClear();

		Transform trans = (Instantiate(Resources.Load("UI/" + uiName)) as GameObject).transform;
		trans.parent = Inst.transform;
		trans.gameObject.SetActive(true);
		trans.localPosition = new Vector3(0, 0, 0);
		trans.localScale = Vector3.one; 
		trans.SendMessage("InitData", data, SendMessageOptions.DontRequireReceiver);
		
		WinStack.Push (trans.gameObject);
		
		return trans.gameObject;
	}

	public static GameObject RequestBrotherUI(string uiName, Dictionary data = null)
	{
		NGUITools.Destroy (WinStack.Pop ());
		
		Transform trans = (Instantiate(Resources.Load("UI/" + uiName)) as GameObject).transform;
		trans.parent = Inst.transform;
		trans.gameObject.SetActive(true);
		trans.localPosition = new Vector3(0, 0, 0);
		trans.localScale = Vector3.one; 
		trans.SendMessage("InitData", data, SendMessageOptions.DontRequireReceiver);
		
		WinStack.Push (trans.gameObject);
		
		return trans.gameObject;
	}

	public static GameObject RequestChildUI(string uiName, Dictionary data = null)
	{
		WinStack.Peek ().SetActive (false);
		
		Transform trans = (Instantiate(Resources.Load("UI/" + uiName)) as GameObject).transform;
		trans.parent = Inst.transform;
		trans.gameObject.SetActive(true);
		trans.localPosition = new Vector3(0, 0, 0);
		trans.localScale = Vector3.one; 
		trans.SendMessage("InitData", data, SendMessageOptions.DontRequireReceiver);
		
		WinStack.Push (trans.gameObject);
		
		return trans.gameObject;
	}

	public static GameObject RequestFatherUI(Dictionary data = null)
	{
		NGUITools.Destroy (WinStack.Pop ());
		WinStack.Peek ().SetActive (true);
		return WinStack.Peek ();
	}

	void start()
	{
		// The code beginning. check and loading configures

	}
}
