using UnityEngine;
using System.Collections;

public abstract class PlotManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public delegate void OnFinish();
	public OnFinish onLoadFinish;

	public abstract void LoadPlot (OnFinish onFinish);
	public abstract void FinishPlotWithNet(); // asyn
	public abstract void FinishPlotWithFile(); // sync
	public abstract void FinishPlotWithOther();


}
