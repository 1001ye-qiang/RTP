using UnityEngine;
using System.Collections;

public sealed class Log
{
    [Range(0, 9)]
    public static int logLevel = 2;

    public static void log(string str)
    {
        if (logLevel >= 1)
            Debug.Log("[qiang.zhou] log " + str);
    }
    public static void debugLog(string str)
    {
        if (logLevel >= 2)
            Debug.Log("[qiang.zhou] log2 " + str);
    }
    public static void logError(string str)
    {
        if(logLevel >= 1)
            Debug.LogError("[qiang.zhou] err " + str);
    }
    public static void debugLogError(string str)
    {
        if(logLevel >= 2)
            Debug.LogError("[qiang.zhou] err2 " + str);
    }
}
