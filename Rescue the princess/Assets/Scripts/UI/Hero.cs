using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {

	bool bForbid = false;
	public bool BForbid{
		get { return bForbid;}
		set { bForbid = value;}
	}
    
    public TriggerColliderMsg tcMsgDun;
    public TriggerColliderMsg tcMsgBody;

    void Start()
    {
        if (tcMsgBody != null)
        {
            tcMsgBody.OnTrigger = OnColliderBody;
        }
        if (tcMsgDun != null)
        {

            tcMsgDun.OnTrigger = OnColliderDun;
        }
    }

	void OnColliderBody(GameObject obj)
	{
        GUIItem gi = obj.GetComponent<GUIItem>();
        if(gi != null && gi.GameProperty is FruitItem)
		{
            FruitItem f = gi.GameProperty as FruitItem;
            BattleManager.Inst.OnCollected(f.weight);
            GameObject.Destroy(obj);
            Log.debugLog("Fruit in Body " + obj.name);
		}

        AttackTrigger at = obj.GetComponent<AttackTrigger>();
        if (at != null)
        {
            BattleManager.Inst.OnAttacked(at.iWeight);
            GameObject.Destroy(obj);
            Log.debugLog("Bullet in Body " + obj.name);
        }
	}

    void OnColliderDun(GameObject obj)
    {
        AttackTrigger at = obj.GetComponent<AttackTrigger>();
        if (at != null && at.bCanRebound)
        {
            obj.name = "heroReturn";
            LineMove lm = obj.GetComponent<LineMove>();
            if (lm != null)
            {
                lm.velocity = new Vector3(lm.velocity.x, -lm.velocity.y);
            }
            Log.debugLog("Bullet in Dun " + obj.name);
        }
    }
}
