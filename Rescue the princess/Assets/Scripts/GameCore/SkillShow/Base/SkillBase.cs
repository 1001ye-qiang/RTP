using UnityEngine;
using System.Collections;

public abstract class SkillBase : MonoBehaviour {

    public delegate void OnFinish();
    OnFinish onfinish;
    abstract public void StartSkill(Actor actor, OnFinish finish);

    // 释放此技能时是否可以同时释放其他技能
    public bool IsMonopolize = true;
    // 释放此技能时是否可以移动
    public bool IsCanMove = false;
}
