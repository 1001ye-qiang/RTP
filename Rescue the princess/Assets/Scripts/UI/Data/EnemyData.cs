using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyData  {
    public int id;
    public int iBoold;
    public string name;
    public float moveSpeed;

    public float interval;
    public int iBulCount;
    public List<BulletItem> bullets = new List<BulletItem>();
}

public class BulletItem{
    public int id;
    public bool bCanRebound;
    public int weight;
    public float speed;
    public int effectId;
}

