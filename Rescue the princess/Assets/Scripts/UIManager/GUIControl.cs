using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 该类适用于被主界面调用的二级界面
/// </summary>
public abstract class GUIControl : MonoBehaviour
{

    /// <summary>
    /// 如果有多个子UI的时候，需要设置默认选择哪个UI
    /// 如果该项为空的话，那么默认只有一个子UI，不需要
    /// 子UI互相切换
    /// </summary>
    public GameObject defaultGameObj;

    /// <summary>
    /// 当前显示的UI
    /// </summary>
    private GameObject currentGameObj;

    /// <summary>
    /// 临时存储子UI
    /// </summary>
    private Dictionary<string, GameObject> uiDic = new Dictionary<string, GameObject>();

    /// <summary>
    /// 初始化UI
    /// </summary>
    private void InitUI()
    {
        uiDic.Clear();
        if (defaultGameObj != null)
        {
            int size = transform.GetChildCount();
            for (int i = 0; i < size; i++)
            {
                GameObject gameObj = transform.GetChild(i).gameObject;
                //排除tab这个组件,因为这个组件还要切换其他UI用
                if (gameObj.name.Equals("Tab"))
                    continue;
                if (!defaultGameObj.name.Equals(gameObj.name))
                    gameObj.SetActive(false);
                else
                    currentGameObj = gameObj;
                uiDic.Add(gameObj.name, gameObj);
            }
        }
    }

    /// <summary>
    /// 关闭UI
    /// </summary>
    protected virtual void Close()
    {
        uiDic.Clear();
        //GUIManage.Instance.SendMessage("CloseRequestUI", gameObject, SendMessageOptions.DontRequireReceiver);
    }

    /// <summary>
    /// 子UI切换
    /// </summary>
    /// <param name="gameObj"></param>
    protected virtual void ChangeUI(GameObject gameObj)
    {
        if (uiDic.ContainsKey(gameObj.name))
        {
            if (!currentGameObj.name.Equals(gameObj.name))
            {
				currentGameObj.SetActive(false);

                uiDic[gameObj.name].SetActive(true);
                currentGameObj = uiDic[gameObj.name];
                ChangeUIFinish(uiDic[gameObj.name], gameObj);
            }
            else
            {
                uiDic[gameObj.name].SetActive(false);
                defaultGameObj.SetActive(true);
                currentGameObj = defaultGameObj;
            }
        }
    }

    /// <summary>
    /// 切换完成后，调用此方法
    /// </summary>
    /// <param name="gameObj">被切换的UI</param>
    /// <param name="clickItemObj">当前点击的条目</param>
    protected virtual void ChangeUIFinish(GameObject gameObj, GameObject clickItemObj)
    {
    }

    /// <summary>
    /// 二级界面初始化
    /// 该方法 代替Start
    /// 可以再该方法内，发送打开UI请求
    /// </summary>
    protected abstract void InitData(Dictionary data);
    /// <summary>
    /// 更新数据
    /// 服务端收到请求以后，返回的时候可以进入该方法内，
    /// 来刷新UI的信息
    /// 参数可以随意增减
    /// </summary>
    public abstract void UpdateData(params System.Object[] v);

}
