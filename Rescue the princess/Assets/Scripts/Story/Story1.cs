using UnityEngine;
using System.Collections;

public class Story1 : GUIControl {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	/// <summary>
	/// 二级界面初始化
	/// 该方法 代替Start
	/// 可以再该方法内，发送打开UI请求
	/// </summary>
	protected override void InitData(Dictionary data)
	{}
	/// <summary>
	/// 更新数据
	/// 服务端收到请求以后，返回的时候可以进入该方法内，
	/// 来刷新UI的信息
	/// 参数可以随意增减
	/// </summary>
	public override void UpdateData(params System.Object[] v)
	{}
}
