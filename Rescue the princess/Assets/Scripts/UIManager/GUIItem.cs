using UnityEngine;
using System.Collections;

public class GUIItem : MonoBehaviour {
    /// <summary>
    /// 每个列表的单元格元素都需要临时保存自己的
    /// 游戏属性，这个obj就是用来临时保存这个属性的
    /// </summary>
    private object obj;
    public object GameProperty
    {
        set
        {
            obj = value;
        }
        get
        {
            return obj;
        }
    }
}
