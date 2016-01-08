using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;

public class StoreConfig {
	string path = Application.persistentDataPath + "/UserData.dat";

	string usename = "";
	string password = "";

	string nickName = "";

	int curLv = 0;
	int curExp = 0;
	int curGlod = 0;
	int curSliver = 0;
	int curEnergy = 0;

	bool bPoint1 = false;

	Dictionary dic = null;
	public object WordsDic(string key)
	{
		if (dic == null)
			dic = new Dictionary ();
		return dic [key];
	}

	public void WriteFile()
	{

		//string json = JsonMapper.ToJson (this);
		//File.WriteAllBytes(path, Encoding.UTF8.GetBytes(json));
	}
	public void ReadFile()
	{
		//string data = File.ReadAllText (path);
		//JsonData jsd = JsonMapper.ToObject (data);

	}

}
