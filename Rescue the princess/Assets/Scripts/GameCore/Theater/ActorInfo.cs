using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActorInfo
{
    public int hp;
    public int maxHp;
    public int speed;
    public bool isHero;
    public string actorRes;

    public List<CSkillConfig> sc = new List<CSkillConfig>();
}

public class CSkillConfig
{
    public int damage;
    public int count;
}
