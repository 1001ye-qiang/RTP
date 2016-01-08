using UnityEngine;
using System.Collections;
using System;

public class UITools
{

    public const int WIDTH = 960;


    public const int HEIGHT = 640;


    public static void SetUILabel(Transform trans, string value)
    {
        if (trans != null && trans.GetComponent<UILabel>() != null)
            trans.GetComponent<UILabel>().text = value;
    }

    public static void SetUILable5(Transform trans, string value, string colorStr)
    {
        if (trans != null && trans.GetComponent<UILabel>() != null)
        {
            if (value == "")
            {
                string text = trans.GetComponent<UILabel>().text;
                if (text.Contains("]"))
                {
                    text = text.Substring(text.IndexOf(']') + 1);
                }
                trans.GetComponent<UILabel>().text = colorStr + text;
            }
            else
            {
                trans.GetComponent<UILabel>().text = colorStr + value;
            }
        }
    }

    public static void SetUILabelAdd(Transform trans, string value)
    {
        if (trans != null && trans.GetComponent<UILabel>() != null)
            trans.GetComponent<UILabel>().text = trans.GetComponent<UILabel>().text + value;
    }

    public static void SetUILabel3(Transform trans, string value, int quality)
    {
        trans.GetComponent<UILabel>().color = Color.white;
        Color colorBianKuang = Color.white;
        switch (quality)
        {
            case 1:
                value = GetColorStr(value, "ffffff");
                colorBianKuang = Color.black;
                break;
            case 2:
                value = GetColorStr(value, "228833");
                break;
            case 3:
                value = GetColorStr(value, "2e64dd");
                break;
            case 4:
            case 5:
            case 6:
                value = GetColorStr(value, "a41cbb");
                break;
        }
        trans.GetComponent<UILabel>().text = value;

        trans.GetComponent<UILabel>().effectColor = colorBianKuang;
    }

    public static string DrawTheColorFromQuality(string value, int quality)
    {


        switch (quality)
        {
            case 1:
                value = GetColorStr(value, "ffffff");
                break;
            case 2:
                value = GetColorStr(value, "228833");
                break;
            case 3:
                value = GetColorStr(value, "2e64dd");
                break;
            case 4:
                value = GetColorStr(value, "a41cbb");
                break;
        }
        return value;


    }

    public static void SetUILabel4(Transform trans, string str, Color color)
    {
        if (trans == null || trans.GetComponent<UILabel>() == null)
            return;

        if (str != null && str != "")
            trans.GetComponent<UILabel>().text = str;

        if (color != null)
            trans.GetComponent<UILabel>().color = color;
    }

    public static void SetUILabel5(Transform trans, string value, Color textColor, Color effectColor)
    {
        if (trans != null && trans.GetComponent<UILabel>() != null)
        {
            trans.GetComponent<UILabel>().text = value;
            trans.GetComponent<UILabel>().color = textColor;
            trans.GetComponent<UILabel>().effectColor = effectColor;
        }
    }
    private static string GetColorStr(string value, string colorStr)
    {
        return "[" + colorStr + "]" + value + "[-]";
    }


    public static void SetUITexture(Transform trans, string pathAndName)
    {
        if (trans.GetComponent<UITexture>() != null && Resources.Load(pathAndName) != null)
        {
            trans.GetComponent<UITexture>().mainTexture = (Texture)Resources.Load(pathAndName);
            trans.GetComponent<UITexture>().gameObject.SetActive(false);
            trans.GetComponent<UITexture>().gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// load asset bundle icon depend on yy code construct.
    /// </summary>
    /// <param name="trans">trans</param>
    /// <param name="headid">format model name</param>
    public static void SetUITexture2(Transform trans, string headid)
    {
        string[] asset = headid.Split('@');
//        PackageManager.Instance.LoadAsset<Texture>("head_" + asset[0] + ":icon@battle_page", delegate(Texture icon)
//        {
//            trans.GetComponent<UITexture>().mainTexture = icon;
//        }, "normal");
    }
	


    public static void destroyChild(Transform trans)
    {
        if (trans.childCount > 0)
        {
            int max = trans.childCount;
            for (int i = 0; i < max; i++)
            {
                UnityEngine.Object.DestroyImmediate(trans.GetChild(0).gameObject);
            }
        }
    }

    public static void destroyGameObject(GameObject go)
    {
        if (go != null)
            UnityEngine.Object.DestroyImmediate(go);
    }

    public static void SetUISprite(Transform trans, int bigQuality)
    {
        UISprite tmpSpr = trans.GetComponent<UISprite>();
        string spriteName = "";
        switch (bigQuality)
        {
            case 4:
            case 5:
            case 6:
                spriteName = "frame_type_4";
                break;
            case 3:
                spriteName = "frame_type_3";
                break;
            case 2:
                spriteName = "frame_type_2";
                break;
            case 1:
            case 0:
                spriteName = "frame_type_1";
                break;
        }
        tmpSpr.atlas = Resources.Load("Atlas/Common/CommonAtlas", typeof(UIAtlas)) as UIAtlas;
        //tmpSpr.atlas = GameObject.Instantiate(Resources.Load("Atlas/Common/CommonAtlas")) as UIAtlas;
        //tmpSpr.
        tmpSpr.spriteName = spriteName;
    }
    public static string GetQuality1(int bigQuality)
    {
        string spriteName = "MPXX003";
        switch (bigQuality)
        {
            case 4:
            case 5:
            case 6:
                spriteName = "frame_type_4";
                break;
            case 3:
                spriteName = "frame_type_3";
                break;
            case 2:
                spriteName = "frame_type_2";
                break;
            case 1:
            case 0:
                spriteName = "frame_type_1";
                break;
        }

        return spriteName;
    }
    /// <summary>
    /// 设置弟子品级 19：A；18：B；7：S；20：C
    /// </summary>
    /// <param name="trans"></param>
    /// <param name="quality"></param>
    public static void SetUISprite2(Transform trans, int bigQuality)
    {
        string spriteName = "";
        switch (bigQuality)
        {
            case 4:
            case 5:
            case 6:
                spriteName = "bg_14";
                break;
            case 3:
                spriteName = "bg_13";
                break;
            case 2:
                spriteName = "bg_12";
                break;
            case 1:
                spriteName = "bg_11";
                break;
            case 0:
                spriteName = "bg_11";
                break;
        }

        trans.GetComponent<UISprite>().spriteName = spriteName;
    }
    public static string GetQuality2(int bigQuality)
    {
        string spriteName = "bg_14";
        switch (bigQuality)
        {
            case 4:
            case 5:
            case 6:
                spriteName = "bg_14";
                break;
            case 3:
                spriteName = "bg_13";
                break;
            case 2:
                spriteName = "bg_12";
                break;
            case 1:
                spriteName = "bg_11";
                break;
            case 0:
                spriteName = "bg_11";
                break;
        }

        return spriteName;
    }

    public static void SetUISprite3(Transform trans, int smaQuality)
    {
        string spriteName = "";
        switch (smaQuality)
        {
            case 1:
                spriteName = "zhuangbei_9";
                break;
            case 2:
                spriteName = "zhuangbei_8";
                break;
            case 3:
                spriteName = "zhuangbei_6";
                break;
            case 4:
                spriteName = "zhuangbei_5";
                break;
            case 5:
            case 0:
                spriteName = "zhuangbei_7";
                break;
        }

        trans.GetComponent<UISprite>().spriteName = spriteName;
        trans.GetComponent<UISprite>().MakePixelPerfect();
    }
    public static String GetQuality3(int smaQuality)
    {
        string spriteName = "zhuangbei_9";
        switch (smaQuality)
        {
            case 1:
                spriteName = "zhuangbei_9";
                break;
            case 2:
                spriteName = "zhuangbei_8";
                break;
            case 3:
                spriteName = "zhuangbei_6";
                break;
            case 4:
                spriteName = "zhuangbei_5";
                break;
            case 5:
            case 0:
                spriteName = "zhuangbei_7";
                break;
        }

        return spriteName;
    }
    public static void SetUISprite6(Transform trans, int bigQuality)
    {
        string spriteName = "";
        switch (bigQuality)
        {
            case 4:
                spriteName = "taozhuang1";
                break;
            case 3:
                spriteName = "taozhuang2";
                break;
            case 2:
                spriteName = "taozhuang3";
                break;

        }

        trans.GetComponent<UISprite>().spriteName = spriteName;
    }


    public static void SetUILabel2(Transform trans, string value)
    {
        UILabel ul = trans.GetComponent<UILabel>();
        ul.text = value;
        ul.effectStyle = UILabel.Effect.Outline;
        ul.effectColor = Color.black;
    }


    /// <summary>
    /// 弟子心情值(心情状态)对应的图片名称
    /// </summary>
    /// <param name='xinqingzhi'>心情值</param>
    public static void DiziXinqingIcon(Transform trans, int xinqingzhi)
    {
        string name = "";
        if (xinqingzhi >= 1)
            name = "17";
        else if (xinqingzhi >= -5 && xinqingzhi < 1)
            name = "21";
        else if (xinqingzhi >= -10 && xinqingzhi < -5)
            name = "19";
        else if (xinqingzhi >= -15 && xinqingzhi < -10)
            name = "20";
        else
            name = "18";
        if (trans != null && trans.GetComponent<UISprite>() != null)
            trans.GetComponent<UISprite>().spriteName = name;
    }
    /// <summary>
    /// 弟子心情状态
    /// </summary>
    /// <param name='xinqingzhi'>心情值</param>
    public static int getXinQingZhuangTai(int xinqingzhi)
    {
        if (xinqingzhi >= 1)
            return 1;
        else if (xinqingzhi >= -5 && xinqingzhi < 1)
            return -5;
        else if (xinqingzhi >= -10 && xinqingzhi < -5)
            return -10;
        else if (xinqingzhi >= -15 && xinqingzhi < -10)
            return -15;
        else
            return -20;
    }
    /// <summary>
    /// 品质对应背景图片,Pinli Image(Atlas)
    /// </summary>
    public static void SetUISprite4(Transform trans, int quality)
    {
        if (trans == null || trans.GetComponent<UISprite>() == null)
        {
            return;
        }
        string spriteName = "17";
        switch (quality)
        {
            case 0:

            case 1:
                spriteName = "17";
                break;
            case 2:
                spriteName = "19";
                break;
            case 3:
                spriteName = "18";
                break;
            case 4:
            case 5:
            case 6:
                spriteName = "16";
                break;

        }

        trans.GetComponent<UISprite>().spriteName = spriteName;
    }
    public static string GetQuanlity4(int quality)
    {

        string spriteName = "17";
        switch (quality)
        {
            case 0:

            case 1:
                spriteName = "17";
                break;
            case 2:
                spriteName = "19";
                break;
            case 3:
                spriteName = "18";
                break;
            case 4:
            case 5:
            case 6:
                spriteName = "16";
                break;

        }

        return spriteName;
    }
    public static void SetUISprite5(Transform trans, string name)
    {
        if (!string.IsNullOrEmpty(name) && trans != null && trans.GetComponent<UISprite>() != null)
        {
            trans.GetComponent<UISprite>().spriteName = name;
        }
    }


    public static void SetUILabel6(Transform trans, int starLv)
    {
        trans.GetComponent<UILabel>().color = Color.white;
        string value = starLv.ToString();
        switch (starLv)
        {
            case 0:
            case 1:
            case 2:
                value = GetColorStr(value, "ffffff");
                break;
            case 3:
            case 4:
                value = GetColorStr(value, "228833");
                break;
            case 5:
            case 6:
                value = GetColorStr(value, "2e64dd");
                break;
            case 7:
            case 8:
            case 9:
            case 10:
                value = GetColorStr(value, "a41cbb");
                break;
        }
        trans.GetComponent<UILabel>().text = value;
    }

    public static void SetGuoshiKuang(Transform transFrame, int gread)
    {
        string sprite = "";
        switch (gread)
        {
            case 1: sprite = "frame_type_2"; break;
            case 2: sprite = "frame_type_3"; break;
            case 3: sprite = "frame_type_4"; break;
            case 4: sprite = "frame_type_5"; break;
            case 5: sprite = "frame_type_5"; break;
        }
        transFrame.GetComponent<UISprite>().spriteName = sprite;

    }

    public static void SetHeroKuang(Transform transFrame, int breakLv)
    {
        string sprite = "";
        switch (breakLv)
        {
            case 1: sprite = "frame_type_1"; break;
            case 2:
            case 3: sprite = "frame_type_2"; break;
            case 4:
            case 5:
            case 6: sprite = "frame_type_3"; break;
            case 7:
            case 8:
            case 9:
            case 10:
            case 11: sprite = "frame_type_4"; break;
            case 12: sprite = "frame_type_5"; break;
        }
        transFrame.GetComponent<UISprite>().spriteName = sprite;
    }

    public static void SetBreakLv(Transform transFrame, Transform transName, int breakLv, string diziName)
    {
        string sprite = "breakLv1";
        string color = "[000000]";
        int showLv = 0;
        switch (breakLv)
        {
            case 0:
                break;

            case 1:
                sprite = "breakLv5";
                color = "[FFFFFF]";
                showLv = 0;
                break;

            case 2:
                sprite = "breakLv3";
                color = "[27c71f]";
                showLv = 0;
                break;

            case 3:
                sprite = "breakLv3";
                color = "[27c71f]";
                showLv = 1;
                break;

            case 4:
                sprite = "breakLv4";
                color = "[23b2fc]";
                showLv = 0;
                break;

            case 5:
                sprite = "breakLv4";
                color = "[23b2fc]";
                showLv = 1;
                break;

            case 6:
                sprite = "breakLv4";
                color = "[23b2fc]";
                showLv = 2;
                break;

            case 7:
                sprite = "breakLv2";
                color = "[e500d9]";
                showLv = 0;
                break;

            case 8:
                sprite = "breakLv2";
                color = "[e500d9]";
                showLv = 1;
                break;

            case 9:
                sprite = "breakLv2";
                color = "[e500d9]";
                showLv = 2;
                break;

            case 10:
                sprite = "breakLv2";
                color = "[e500d9]";
                showLv = 3;
                break;

            case 11:
                sprite = "breakLv2";
                color = "[e500d9]";
                showLv = 4;
                break;

            case 12:
                sprite = "breakLv1";
                color = "[fa6b15]";
                showLv = 0;
                break;
        }
        transFrame.GetComponent<UISprite>().spriteName = sprite;
        if (showLv == 0)
            transName.GetComponent<UILabel>().text = color + diziName;
        else
            transName.GetComponent<UILabel>().text = color + diziName + " + " + showLv.ToString();

    }

    /// <summary>
    /// 设置英雄职业图标
    /// </summary>
    /// <param name="trans"></param>
    /// <param name="Occu">职业代码</param>
    public static void SetOccupationIcon(Transform trans, int Occu)
    {
        string sprite = "hero_equip_1";
        switch (Occu)
        {
            case 1:
                sprite = "hero_equip_1";
                break;
            case 2:
                sprite = "hero_equip_3";
                break;
            case 3:
                sprite = "hero_equip_5";
                break;
            case 4:
                sprite = "hero_equip_2";
                break;
            case 5:
                sprite = "hero_equip_4";
                break;
        }
        trans.GetComponent<UISprite>().spriteName = sprite;

    }
    /// <summary>
    /// 设置英雄职业图标背景(英雄职业图标背景颜色随着属性代码变化而变化)
    /// </summary>
    /// <param name="trans"></param>
    /// <param name="attr">属性代码</param>
    public static void SetOccupationBg(Transform trans, int attr)
    {
        string sprite = "hero_type_bg_1";
        switch (attr)
        {
            case 1:
                sprite = "hero_type_bg_1";
                break;
            case 2:
                sprite = "hero_type_bg_2";
                break;
            case 3:
                sprite = "hero_type_bg_4";
                break;
            //case 4:
            //    sprite = "tFW6";
            //    break;
            //case 5:
            //    sprite = "tFW7";
            //    break;
            case 6:
                sprite = "hero_type_bg_3";
                break;
            case 7:
                sprite = "hero_type_bg_5";
                break;
        }
        trans.GetComponent<UISprite>().spriteName = sprite;


    }
    /// <summary>
    /// 设置英雄职业属性
    /// </summary>
    /// <param name="trans"></param>
    /// <param name="attr">属性代码</param>
    public static void SetAttribute(Transform trans, int attr)
    {
        string sprite = "hero_type_1";
        switch (attr)
        {
            case 1:
                sprite = "hero_type_1";
                break;
            case 2:
                sprite = "hero_type_2";
                break;
            case 3:
                sprite = "hero_type_4";
                break;
            //case 4:
            //    sprite = "tu";
            //    break;
            //case 5:
            //    sprite = "lei";
            //    break;
            case 6:
                sprite = "hero_type_3";
                break;
            case 7:
                sprite = "hero_type_5";
                break;
        }
        trans.GetComponent<UISprite>().spriteName = sprite;


    }


    public static void SetLayer(GameObject obj, int layer)
    {
        obj.layer = layer;
        if (obj.transform.childCount > 0)
        {
            for (int i = 0; i < obj.transform.childCount; ++i)
            {
                SetLayer(obj.transform.GetChild(i).gameObject, layer);
            }
        }
    }
}
