using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RadialLineBulletLoadder : MonoBehaviour {
    public List<RadialLineBulletItem> lstLbi;
    public Actor actor;

    UISprite boss;
    void OnEnable()
    {
        actor.IsBusy = true;
        boss = actor.GetComponentInChildren<UISprite>();
        TweenColor tc = TweenColor.Begin(boss.gameObject, 0.5f, Color.red);
        tc.style = UITweener.Style.PingPong;
        StartCoroutine(delayFight(tc));

        runEnd = false;
        runBegin = false;
    }

    void OnDisable()
    {
        actor.IsBusy = false;
    }

    IEnumerator delayFight(TweenColor tc)
    {
        yield return new WaitForSeconds(2f);
        Destroy(tc);
        boss.color = Color.white;
        allTime = 0;
        tmpLst.AddRange(lstLbi);
        runBegin = true;
    }

    IEnumerator randomPos()
    {
        yield return new WaitForSeconds(1);
        TweenAlpha.Begin(boss.gameObject, 0.4f, 0);
        yield return new WaitForSeconds(0.4f);
        actor.transform.localPosition = new Vector3(Random.Range(-350, 350), actor.transform.localPosition.y);
        TweenAlpha.Begin(boss.gameObject, 0.4f, 1);
        yield return new WaitForSeconds(2.1f);
        gameObject.SetActive(false);
    }

    List<RadialLineBulletItem> tmpLst = new List<RadialLineBulletItem>();
    float allTime = 0;
    bool runBegin = false;
    bool runEnd = false;
    void Update()
    {
        allTime += Time.deltaTime;

        if (tmpLst.Count > 0 && allTime > tmpLst[0].time)
        {
            RadialLineBulletItem lbi = tmpLst[0];
            tmpLst.RemoveAt(0);
            GameObject obj = GameObject.Instantiate(lbi.prefab) as GameObject;
            obj.transform.parent = transform.parent.parent;
            obj.transform.position = transform.position;
            obj.transform.localScale = Vector3.one;
            obj.transform.localRotation = Quaternion.identity;

            LineMove lm = obj.AddComponent<LineMove>();

            Vector3 direction = new Vector3(Mathf.Sin(lbi.angle * Mathf.Deg2Rad), -Mathf.Cos(lbi.angle * Mathf.Deg2Rad), 0);
            lm.acceleration = direction * lbi.acceleration;
            lm.velocity = direction * lbi.speed;
            lm.distance = lbi.distance;

            AttackTrigger at = obj.AddComponent<AttackTrigger>();
            at.bCanRebound = lbi.canRebound;
            at.iWeight = lbi.damage;
        }
        if (tmpLst.Count == 0 && runEnd == false && runBegin == true)
        {
            StartCoroutine(randomPos());
            runEnd = true;
            runBegin = false;
        }
    }


}




[System.Serializable]
public class RadialLineBulletItem
{
    public GameObject prefab;
    public float time;

    public float speed;
    public float acceleration;
    public float angle;

    public float distance;
    //public LineMove lm;
    public bool canRebound = false;

    public int damage;
}


