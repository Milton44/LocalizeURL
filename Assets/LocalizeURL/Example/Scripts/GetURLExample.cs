using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LocalizeURL;

public class GetURLExample : MonoBehaviour
{
    public URLId urlId;

    private void Start()
    {
       Debug.Log(urlId.GetURLFormat("value_0","value_1", "value_2", 3));
    }

}
