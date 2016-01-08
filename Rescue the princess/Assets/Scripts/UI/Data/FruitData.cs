using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FruitData {
    public int id;
    public string name;
    public float interval;
    public int minGet;
    public List<FruitItem> fruits = new List<FruitItem>();
}

public class FruitItem
{
    public int id;
    public string name;
    public int weight;
    public float speed;
    public int type;
}
