using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleManager : MonoBehaviour {
	public static BattleManager Inst;
	void Awake()
	{
		Inst = this;
        itemInit();//////////////
	}

	//List<Hero> lstHero = new List<Hero>();
	Hero h;
	public int bloodMax = 10;
	public UILabel labCollection;
    public UILabel labHeroBlood;
    public UISlider bossBlood;
    public UILabel labBossBlood;


	// Use this for initialization
	void Start () {
		h = transform.Find ("Hero").GetComponent<Hero> ();
		
		labCollection = transform.Find ("FruitSets/Label").GetComponent<UILabel>();
        labHeroBlood = transform.Find("HeroInfo/Label").GetComponent<UILabel>();
        bossBlood = transform.Find("BossInfo/Blood").GetComponent<UISlider>();
        labBossBlood = transform.Find("BossInfo/Label").GetComponent<UILabel>();

        UIEventListener.Get(transform.Find("HeroController/left").gameObject).onPress = OnPressLeft;
        UIEventListener.Get(transform.Find("HeroController/right").gameObject).onPress = OnPressRight;
        UIEventListener.Get(transform.Find("StartBtn").gameObject).onClick = OnClickStart;
    }

    void OnClickStart(GameObject obj)
    {
        transform.Find("StartBtn").gameObject.SetActive(false);
        StartCoroutine(RunGame(_data));
    }

    float curSpeed = 0f;
	// Update is called once per frame
	void Update () {

        float ho = Input.GetAxis("Horizontal");
        
        float curSpeed = GetCurSpeed(bPressLeft || ho < -0.01f, (bPressRight || ho > 0.01f) || (bPressLeft || ho < -0.01f), Time.deltaTime);
        Vector3 curPos = h.transform.localPosition;
        if (curPos.x < -440f && curSpeed < 0 || curPos.x > 440f && curSpeed > 0)
        {
            curSpeed = 0;
            return;
        }
        h.transform.localPosition = curPos + new Vector3(Time.deltaTime * curSpeed, 0, 0);
	}

    // 惯性和加速度
    float GetCurSpeed(bool isLeft, bool isOpt, float deltaTime)
    {
        float aSpeed = _hero.iMoveSpeed;
        if (isOpt)
        {
            if (isLeft)
            {
                if (curSpeed > 0)
                    curSpeed -= deltaTime * aSpeed * 2;
                else if (curSpeed > -_hero.iMoveSpeed)
                    curSpeed -= deltaTime * aSpeed;
                else
                    curSpeed = -_hero.iMoveSpeed;
            }
            else
            {
                if (curSpeed < 0)
                    curSpeed += deltaTime * aSpeed * 2;
                else if (curSpeed < _hero.iMoveSpeed)
                    curSpeed += deltaTime * aSpeed;
                else
                    curSpeed = _hero.iMoveSpeed;
            }
        }
        else
        {
            if (curSpeed > float.Epsilon)
            {
                curSpeed -= deltaTime * aSpeed;
                if(curSpeed <= float.Epsilon)
                    curSpeed = 0f;
            }
            else if (curSpeed < -float.Epsilon)
            {
                curSpeed += deltaTime * aSpeed;
                if (curSpeed >= -float.Epsilon)
                    curSpeed = 0f;
            }
            else
            {
                curSpeed = 0f;
            }
        }
        return curSpeed;
    }

    // controller
    bool bPressLeft = false;
    void OnPressLeft(GameObject obj, bool isPress)
    {
        bPressLeft = isPress;
    }
    bool bPressRight = false;
    void OnPressRight(GameObject obj, bool isPress)
    {
        bPressRight = isPress;
    }

    int curFruits = 0;
    int curHeroBlood = 0;
    int curBossBlood = 0;
    //////////////////////////////////////////////////////////////
    PveLevelItemData _data = new PveLevelItemData();
    HeroDynamicData _hero = new HeroDynamicData();
    void itemInit()
    {
        _hero.iBood = 5;
        _hero.iMoveSpeed = 210f;

        _data.jqName = "level1JQ";

        FruitData fd = new FruitData();
        fd.name = "order1";
        fd.interval = 0.4f;
        fd.minGet = 7;
        FruitItem fi = new FruitItem();
        fi.name = "fruit1";
        fi.weight = 1;
        fi.speed = 100;
        for(int i = 0; i < 11; ++i)
            fd.fruits.Add(fi);

        _data.fruit = fd;

        EnemyData ed = new EnemyData();
        ed.iBoold = 8;
        ed.moveSpeed = 160;
        ed.interval = 1f;
        ed.iBulCount = 12;
        for (int i = 0; i < ed.iBulCount; ++i)
        {
            BulletItem bd = new BulletItem();
            int range = Random.Range(0, 2);
            bd.bCanRebound = range == 0 ? false : true;
            bd.weight = 1;
            bd.speed = 100;
            ed.bullets.Add(bd);
        }

        _data.enemy = ed;

    }

    ///////////////////////////////////////////////////////////////
    GameObject bossObj;
    IEnumerator RunGame(PveLevelItemData data)
    {

        #region step 1 // juQing
        curFruits = 0;
        curHeroBlood = _hero.iBood;
        curBossBlood = data.enemy.iBoold;
        labCollection.text = curFruits.ToString();
        labHeroBlood.text = curHeroBlood.ToString();
        labBossBlood.text = curBossBlood.ToString();
        bossBlood.value = 1;
        h.transform.localPosition = new Vector3(0f, h.transform.localPosition.y, 0f);
        #endregion step 1 // juQing
        
        #region step 2 //set value
        GameObject obj;// = GameObject.Instantiate(Resources.Load("UI/Pve/" + data.jqName)) as GameObject;
        
        /*//GameObject obj = GameObject.Instantiate(Resources.Load("UI/Pve/" + data.jqName)) as GameObject;
        //obj.transform.parent = transform;
        //obj.transform.localRotation = Quaternion.identity;
        //obj.transform.localPosition = Vector3.zero;
        //obj.transform.localScale = Vector3.one;
        //yield return new WaitForSeconds(7.6f);

        //iTween.ShakePosition(transform.parent.gameObject, new Vector3(0.1f, 0.1f, 0), 1f);
        //yield return new WaitForSeconds(1f);
        #endregion step 2 //set value

        #region step 3 //start ani fruit
        UITools.destroyChild(transform.Find("Fruits"));
        foreach (FruitItem item in data.fruit.fruits)
        {
            GameObject objFi = GameObject.Instantiate(transform.Find("prefab/" + item.name).gameObject) as GameObject;
            objFi.SetActive(true);
            objFi.transform.parent = transform.Find("Fruits");
            objFi.transform.localRotation = Quaternion.identity;
            objFi.transform.localPosition = new Vector3(Random.Range(-400, 400), 0, 0f);
            objFi.transform.localScale = Vector3.zero;

            GUIItem gi = objFi.AddComponent<GUIItem>();
            gi.GameProperty = item;

            // another couroute
            TweenScale.Begin(objFi, 0.5f, Vector3.one);
            yield return new WaitForSeconds(0.5f);

            // shark
            //iTween.ShakePosition(objFi, new Vector3(0.05f, 0.01f, 0), 1f);
            iTween.ShakeRotation(objFi, new Vector3(0, 0, 10f), 1f);
            yield return new WaitForSeconds(1f);

            EndDestory ed = objFi.AddComponent<EndDestory>();
            TweenPosition tp = TweenPosition.Begin(objFi, 640 / (item.speed + Random.Range(-30f, 30f)), new Vector3(objFi.transform.localPosition.x, objFi.transform.localPosition.y - 640, 0));
            tp.SetOnFinished(ed.OnFinish);
            yield return new WaitForSeconds(data.fruit.interval);
        }
        #endregion step 3 //start ani

        yield return new WaitForSeconds(5 - data.fruit.interval);
        if (curFruits < data.fruit.minGet)
        {
            IsOver(false);
            yield break;
        }

        GameObject notice = GameObject.Instantiate(transform.Find("prefab/notice").gameObject) as GameObject;
        notice.gameObject.SetActive(true);
        notice.transform.parent = transform;
        notice.transform.localScale = Vector3.one;
        notice.GetComponent<UILabel>().text = "Turn 2, Boss is coming!";
        yield return new WaitForSeconds(4);

        #region step 4 //start ani boss
        // warning
        obj = GameObject.Instantiate(Resources.Load("UI/Pve/BeginWarning")) as GameObject; // 1.5s
        obj.transform.parent = transform;
        obj.transform.localRotation = Quaternion.identity;
        obj.transform.localPosition = new Vector3(0, 410f, 0);
        obj.transform.localScale = new Vector3(5f, 5f, 0);

        yield return new WaitForSeconds(2f);*/
        // boss
        //bossObj = GameObject.Instantiate(Resources.Load("UI/Enemy/Boss")) as GameObject;
        //bossObj.transform.parent = transform;
        //bossObj.transform.localRotation = Quaternion.identity;
        //bossObj.transform.localPosition = new Vector3(0, 430f, 0f);
        //bossObj.transform.localScale = Vector3.one;
        //TweenPosition.Begin(bossObj, 1.2f, new Vector3(0, 210f, 0));

        bossObj = GameObject.Instantiate(Resources.Load("UI/Enemy/Boss_1")) as GameObject;
        bossObj.transform.parent = transform;
        bossObj.transform.localRotation = Quaternion.identity;
        bossObj.transform.localPosition = new Vector3(0, 430f, 0f);
        bossObj.transform.localScale = new Vector3(0.7f, 0.7f, 0);

        Actor actor = bossObj.GetComponent<Actor>();
        actor.TragetPos = new Vector3(0, 230f, 0);


        yield return new WaitForSeconds(2f);

        actor.RunFight = true;
        //Boss boss = bossObj.GetComponent<Boss>();
        //boss.StartMove();
        //boss.SetStart(data.enemy, BossState.StartBattle);

        #endregion step 4

        #region step 5 // game
        // Check Hero states and update staus;
        // Check End;
        #endregion step 5 // game
    }
    
    void OnDestory()
    {
        CancelInvoke();
    }

    public void OnCollected(int count)
	{
        if (labCollection != null && count > 0)
        {
            curFruits += count;
            labCollection.text = curFruits.ToString();
        }
    }
	public void OnAttacked(int blood)
	{
        if (labHeroBlood != null && blood > 0 && curHeroBlood > 0)
        {
            if (curHeroBlood >= blood)
            {
                curHeroBlood -= blood;
                labHeroBlood.text = curHeroBlood.ToString();
            }
            else
            {
                curHeroBlood = 0;
                labHeroBlood.text = "0";

            }
            if (curHeroBlood == 0)
                IsOver(false);
        }
	}

    public void OnBossAttacked(int blood)
    {
        if (labBossBlood != null && blood > 0 && curBossBlood > 0)
        {
            if (curBossBlood >= blood)
            {
                curBossBlood -= blood;
                labBossBlood.text = curBossBlood.ToString();
            }
            else
            {
                curBossBlood = 0;
                labBossBlood.text = "0";
            }
            if(curBossBlood == 0)
                IsOver(true);

            bossBlood.value = (float)curBossBlood / (float)_data.enemy.iBoold;
        }
    }
    
	public void OnFinished()
	{
		transform.Find ("Label").gameObject.SetActive (false);
	}

    public void IsOver(bool isWin)
    {
        UITools.destroyChild(transform.Find("Effect"));
        UITools.destroyChild(transform.Find("Fruits"));
        UITools.destroyChild(transform.Find("Bullets"));
        GameObject.Destroy(bossObj);

        GameObject notice = GameObject.Instantiate(transform.Find("prefab/notice").gameObject) as GameObject;
        notice.gameObject.SetActive(true);
        notice.transform.parent = transform;
        notice.transform.localScale = Vector3.one;
        if (isWin)
        {
            notice.GetComponent<UILabel>().text = "Congratulations, make persistent efforts!";
        }
        else
        {
            notice.GetComponent<UILabel>().text = "Game over!!";
        }
        Invoke("ShowRestart", 2.5f);
    }

    void ShowRestart()
    {
        transform.Find("StartBtn").gameObject.SetActive(true);
    }
}
