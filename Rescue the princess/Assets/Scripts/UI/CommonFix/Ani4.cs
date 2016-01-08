using UnityEngine;
using System.Collections;

public class Ani4 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(RunAni());
	}

    IEnumerator RunAni()
    {
        yield return new WaitForSeconds(1);
        Vector2 curSc = getLocalScreen();

        float x = curSc.x / 4;
        float y = curSc.y / 4;

        Transform trans = transform.Find("1");
        Vector3 pos = new Vector3(-x, y, 0);
        TweenPosition.Begin(trans.gameObject, 1.5f, pos);
        yield return new WaitForSeconds(1.6f);

        trans = transform.Find("2");
        pos = new Vector3(x, y, 0);
        TweenPosition.Begin(trans.gameObject, 1.5f, pos);
        yield return new WaitForSeconds(1.6f);

        trans = transform.Find("3");
        pos = new Vector3(-x, -y, 0);
        TweenPosition.Begin(trans.gameObject, 1.5f, pos);
        yield return new WaitForSeconds(1.6f);

        trans = transform.Find("4");
        pos = new Vector3(x, -y, 0);
        TweenPosition.Begin(trans.gameObject, 1.5f, pos);
        yield return new WaitForSeconds(1.7f);

        Destroy(gameObject);

    }

    Vector2 getLocalScreen()
    {
        Vector2 rst = new Vector2();
        float rate = (float)Screen.width / (float)Screen.height;
        if (rate > 1.5)
        {
            rst.x = (float)640 * rate;
            rst.y = 640;
        }
        else
        {
            rst.x = 960;
            rst.y = (float)960 / rate;
        }
        return rst;
    }

}
