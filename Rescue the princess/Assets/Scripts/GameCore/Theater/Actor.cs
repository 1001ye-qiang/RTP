using UnityEngine;
using System.Collections;


// any state is a skill, above idle
public class Actor : PhysicBase
{
    float Screenwidth = 0;
	// Use this for initialization
	void Start () {
        OnTrigger = OnCollider;

        float rate = (float) Screen.width / (float)Screen.height;
        Screenwidth = rate > 1.5 ? rate * 640 : 960;
	}

    int width = 160;
	// Update is called once per frame
    void Update()
    {
        if (transform.localPosition.x > Screenwidth / 2 - width && velocity.x > 0 ||
            transform.localPosition.x < -Screenwidth / 2 + width && velocity.x < 0)
        {
            velocity.x = -velocity.x;
        }
        transform.localPosition += velocity * Time.deltaTime;
        velocity += acceleration * Time.deltaTime;
        if (enableTragetPos)
        {
            if((transform.localPosition - TragetPos).sqrMagnitude < 9f)
            {
                velocity = Vector3.zero;
                acceleration = Vector3.zero;
                enableTragetPos = false;
            }
        }
        if (RunFight && IsBusy == false)
        {
            int i = Random.Range(0, 100);
            if(i < 90)
                Skill(0);
            else{
                int j = Random.Range(0, 100);
                Skill((j % (skill.Length - 1)) + 1);
            }
        }
	}

    void OnCollider(GameObject obj)
    {
        AttackTrigger at = obj.GetComponent<AttackTrigger>();
        if (at == null) return;
        if (at.bCanRebound && obj.name == "heroReturn")
        {
            BattleManager.Inst.OnBossAttacked(at.iWeight);
            GameObject.Destroy(obj);
            Log.debugLog("Bullet in Boss " + obj.name);
        }
    }

}
