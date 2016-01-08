using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum BossState{
    StartBattle,
    Battle2,
    Battle3,
    Win,
    Lost
}

public class Boss : MonoBehaviour {

	// Update is called once per frame
	void Update () {
	
	}

    public void SetStart(EnemyData ed, BossState bs)
    {
        switch (bs)
        {
            case BossState.StartBattle:
                StartBattle(ed);
                break;
            case BossState.Lost:
                break;
            case BossState.Win:
                break;
        }
    }

    public void StartMove()
    {
        TweenPosition tp = TweenPosition.Begin(transform.Find("boss").gameObject, 0.5f, new Vector3(0, 5f, 0));
        tp.style = UITweener.Style.PingPong;
    }

    IEnumerator AdjustMove(float speed)
    {
        float minX = -333f;
        float maxX = 333f;
        float time = (transform.localPosition.x - minX) / speed;
        TweenPosition.Begin(gameObject, time, new Vector3(minX, transform.localPosition.y));
        yield return new WaitForSeconds(time);
        TweenPosition tp2 = TweenPosition.Begin(gameObject, (maxX - transform.localPosition.x) / speed, new Vector3(maxX, transform.localPosition.y));
        tp2.from = new Vector3(minX, transform.localPosition.y);
        tp2.style = UITweener.Style.PingPong;

    }

    void StartBattle(EnemyData ed)
    {
        StartCoroutine(AdjustMove(ed.moveSpeed));
        StartCoroutine(BulletsPump(ed));
    }


    IEnumerator BulletsPump(EnemyData ed)
    {
        if (ed.iBulCount <= 0) yield break;
        List<GameObject> lstBu = new List<GameObject>();
        Transform buTrans = transform.Find("bullet1");
        lstBu.Add(buTrans.gameObject);
        buTrans = transform.Find("bullet2");
        lstBu.Add(buTrans.gameObject);

        float maxBiTime = 0;
        while(true) // 必须一方死
        //foreach(BulletItem item in ed.bullets)
        {
            BulletItem item = ed.bullets[Random.Range(0, ed.bullets.Count)];
            GameObject obj = null;
            if (item.bCanRebound)
                obj = lstBu[0];
            else
                obj = lstBu[1];

            GameObject tmp = GameObject.Instantiate(obj) as GameObject;
            tmp.transform.parent = transform.parent.Find("Bullets");
            tmp.transform.localScale = Vector3.one;
            tmp.transform.localRotation = Quaternion.identity;
            tmp.transform.position = obj.transform.position;
            tmp.SetActive(true);
            tmp.name = "bullet";

            GUIItem gi = tmp.AddComponent<GUIItem>();
            gi.GameProperty = item;
            
            float dst = tmp.transform.localPosition.y - 640f;
            float time = 640f / item.speed;

            EndDestory end = tmp.AddComponent<EndDestory>();
            TweenPosition tp = TweenPosition.Begin(tmp, time, new Vector3(tmp.transform.localPosition.x, dst, 0));
            tp.SetOnFinished(end.OnFinish);

            if (time > maxBiTime)
            {
                maxBiTime = time;
            }
            yield return new WaitForSeconds(ed.interval);
        }
        //yield return new WaitForSeconds(maxBiTime - ed.interval);
        //BattleManager.Inst.IsOver(true);
    }

    void Start()
    {
        TriggerColliderMsg tcMsg = gameObject.GetComponent<TriggerColliderMsg>();
        if (tcMsg == null)
        {
            tcMsg = gameObject.AddComponent<TriggerColliderMsg>();
        }
        tcMsg.OnTrigger = OnCollider;
    }
    void OnCollider(GameObject obj)
    {
        GUIItem gi = obj.GetComponent<GUIItem>();
        if (gi == null) return;
        if (gi.GameProperty is BulletItem)
        {
            BulletItem b = gi.GameProperty as BulletItem;
            if (b.bCanRebound && obj.name == "heroReturn")
            {
                BattleManager.Inst.OnBossAttacked(b.weight);
                GameObject.Destroy(obj);
                Log.debugLog("Bullet in Boss " + obj.name);
            }
        }
    }
}
