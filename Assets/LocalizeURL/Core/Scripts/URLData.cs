using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RotaryHeart.Lib.SerializableDictionary;

namespace LocalizeURL
{
    using System;

    [Serializable]
    public class URL
    {
        [Header("URLs")]
        [TextArea]
        public string production;

       
        [TextArea]
        public string test;

        public string GetURLValue()
        {
            if (URLData.TestMode)
                return test;
            else
                return production;
        }

        public string GetURLValue(params object[] args)
        {
            return string.Format(GetURLValue(), args);
        }

    }   

    [Serializable]
    public class DictionaryURL: SerializableDictionaryBase<string, URL> { }

    public class URLData : ScriptableObject
    {

        #region Singleton 
        private static URLData instance;
        public static URLData Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = Resources.Load<URLData>("URL Data");
                }

                return instance;
            }

            set
            {
                instance = value;
            }
        } 


        #endregion

        public static bool TestMode
        {
            get => Instance._testMode;
            set => Instance._testMode = value;
        }

        public static DictionaryURL DictionaryURL
        {
            get => Instance._dictionaryURL;
        } 

        [SerializeField]
        private bool _testMode; 

        [SerializeField]
        private DictionaryURL _dictionaryURL; 


        public static URL GetURLData(string id)
        {
            return Instance._dictionaryURL[id];
        }

        public static URL GetURLData(URLId urlId)
        {
            return GetURLData(urlId.id);
        }
    }
}
