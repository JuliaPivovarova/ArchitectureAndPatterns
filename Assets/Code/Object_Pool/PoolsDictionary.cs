using System.Collections.Generic;
using UnityEngine;

namespace Code.Object_Pool
{
    internal static class PoolsDictionary
    {
        private static Dictionary<string, WorkWithPool> _poolsDictionary;

        static PoolsDictionary()
        {
            _poolsDictionary = new Dictionary<string, WorkWithPool>();
        }

        public static void AddToDic(string name, Transform rootPool, GameObject[] poolObjects)
        {
            WorkWithPool wwPool = new WorkWithPool(rootPool, name, poolObjects);
            _poolsDictionary.Add(name, wwPool);
        }

        public static WorkWithPool GetFromDic(string name)
        {
            return _poolsDictionary[name];
        }
    }
}