using System;
using UnityEngine;

namespace NEEEU.ActionChain.Sample
{
    public class Log : MonoBehaviour
    {
        public static void debug(string text)
        {
            Debug.Log(text);
        }

        public static void d(int num)
        {
            debug("" + num);
        }

        public static void d(string text)
        {
            debug(text);
        }

        public static void error(string text)
        {
            Debug.LogError(text);
        }
    
        public static void e(string text)
        {
            error(text);
        }
    }
}

