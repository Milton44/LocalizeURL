using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Malee;
namespace LocalizeURL
{
    [System.Serializable]
    public class URLId
    {
        public string id;

        public bool customParams = false;

        public string separatorParams = "&";
        public string separatorKeyAndValue = "=";

        [System.Serializable]
        public class ReorderableString : ReorderableArray<string> { }

        [Reorderable]
        public ReorderableString urlParams = new ReorderableString();

        public string GetURL()
        {
            if (customParams)
            {
                string urlFormat = URLData.GetURLData(id).GetURLValue();
                for (int i = 0; i < urlParams.Count; i++)
                {
                    if ( i != urlParams.Count - 1)
                        urlFormat += urlParams[i]+ separatorKeyAndValue+"{" + i + "}" + separatorParams;
                    else
                        urlFormat += urlParams[i] + separatorKeyAndValue+"{" + i + "}";
                }

                return urlFormat;
            }
            else
            {
                return URLData.GetURLData(id).GetURLValue();
            }
        }
        public string GetURLFormat(params object[] args)
        {
            return string.Format(GetURL(), args);
        }

    }
}
