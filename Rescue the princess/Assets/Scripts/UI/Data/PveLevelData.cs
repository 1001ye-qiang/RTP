using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PveLevelData
{
    public int id;
    public string name;
    public string dsc;
    public string image;
    public Vector3 Pos;
    public SortedList<int, PveLevelItemData> smallLvs = new SortedList<int, PveLevelItemData> ();
}


public class PveLevelItemData
{
    public int id;
    public string name;
    public string dsc;
    public int parentId;
    public int tiLi;
    public int limitCount;
    public int baseExperience;
    public int silver;
    public int gold;
    public int packageId;
    public int sceneName;
    public int flushGold;
    public float strengthRate;
    public string backSound;
    public EnemyData enemy;
    public Vector3 pos;
    public bool bFightAgain;

    public string jqName;
    public int juQingId;
    public FruitData fruit;
}