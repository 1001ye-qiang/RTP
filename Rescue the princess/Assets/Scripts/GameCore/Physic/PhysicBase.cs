using UnityEngine;
using System.Collections;

public class PhysicBase : TriggerColliderMsg
{
    public Vector3 velocity;
    public Vector3 acceleration;

    public TriggerColliderMsg[] colliders;

    public Vector3 Velocity
    {
        set { velocity = value; }
        get { return velocity; }
    }
    public Vector3 Acceleration
    {
        set { acceleration = value; }
    }

    public bool enableTragetPos = false;
    public Vector3 tragetPos;
    public Vector3 TragetPos
    {
        set
        {
            tragetPos = value;
            enableTragetPos = true;
            Velocity = (TragetPos - transform.localPosition).normalized * speed;
        }
        get { return tragetPos; }
    }

    bool isBusy = false;
    public bool IsBusy
    {
        set { isBusy = value; }
        get { return isBusy; }
    }
    bool isRunFight = false;
    public bool RunFight
    {
        set { isRunFight = value; }
        get { return isRunFight; }
    }

    public GameObject[] skill;
    protected void Skill(int index)
    {
        if (skill.Length <= index)
            return;
        Debug.LogError(index);
        if (index != 0)
            Velocity = Vector3.zero;
        else if (Mathf.Abs(Velocity.sqrMagnitude) <= float.Epsilon)
        {
            Velocity = new Vector3(speed, 0);
        }

        for (int i = 0; i < skill.Length; ++i)
        {
            if (index == i)
                skill[i].SetActive(true);
            else
                skill[i].SetActive(false);
        }
    }

}
