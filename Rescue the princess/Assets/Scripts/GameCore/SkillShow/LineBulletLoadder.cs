using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LineBulletLoadder : MonoBehaviour {
    public List<LineBulletItem> lstLbi;

    public Actor actor;
    void OnEnable()
    {
        countTime = 0;
        actor.IsBusy = true;
        StartCoroutine(delayDisable());
    }
    void OnDisable()
    {
        actor.IsBusy = false;
    }

    IEnumerator delayDisable()
    {
        yield return new WaitForSeconds(1.3f);
        gameObject.SetActive(false);
    }

    float interval = 1.2f;
    float countTime;
    void Update()
    {
        countTime += Time.deltaTime;
        if (lstLbi.Count > 0 && countTime > interval)
        {
            countTime = 0;
            int i = Random.Range(0, lstLbi.Count);

            LineBulletItem lbi = lstLbi[i];
            GameObject obj = GameObject.Instantiate(lbi.prefab) as GameObject;
            obj.transform.parent = transform.parent.parent;
            obj.transform.position = transform.position;
            obj.transform.localScale = Vector3.one;
            obj.transform.localRotation = Quaternion.identity;

            LineMove lm = obj.AddComponent<LineMove>();
            lm.acceleration = lbi.acceleration;
            lm.velocity = lbi.velocity;
            lm.distance = lbi.distance;

            AttackTrigger at = obj.AddComponent<AttackTrigger>();
            at.bCanRebound = lbi.canRebound;
            at.iWeight = lbi.damage;
        }
    }
}

[System.Serializable]
public class LineBulletItem
{
    public GameObject prefab;

    public Vector3 velocity;
    public Vector3 acceleration;
    //public float gravity;
    public float distance;
    //public LineMove lm;

    public bool canRebound;
    public int damage;
}


