using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;


public class Dictionary : Dictionary<object, object>
{
    public object GetValue(object key)
    {
        return this[key];
    }
    public override string ToString()
    {
        ArrayList ks = new ArrayList(this.Keys);
        ArrayList vs = new ArrayList(this.Values);
        StringBuilder temp = new StringBuilder("Dictionary Content: {\n");
        for (int i = 0; i < ks.Count; i++)
        {
            temp.Append("\t").Append(ks[i]).Append(" -> ").Append(vs[i]).Append("\n");
        }
        temp.Append("}\r\n\r\n");
        return temp.ToString();
    }
}