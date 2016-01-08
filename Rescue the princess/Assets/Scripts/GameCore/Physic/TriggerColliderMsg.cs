using UnityEngine;
using System.Collections;

public class TriggerColliderMsg : MonoBehaviour {

    public delegate void SthEnter(GameObject obj);
    public SthEnter OnTrigger;
    public SthEnter OnCollision;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider cd)
    {
        if (OnTrigger != null)
        {
            OnTrigger(cd.gameObject);
            Log.debugLog(cd.gameObject.name + " trigger enter " + gameObject.name);
        }
    }
    void OnCollisionEnter(Collision cs)
    {
        if (OnCollision != null)
        {
            OnCollision(cs.gameObject);
            Log.debugLog(cs.gameObject.name + " collision enter " + gameObject.name);
        }
    }
}
