using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
// [UnityEngine.JSONSerializeModule];

// [Serializable]
public class ButtonScript : MonoBehaviour {
    string path;
    string jsonString;
    public RawImage[] buttonList;
    private string[] webSiteUrl;
    // Start is called before the first frame update
    IEnumerator Start () {

        var path = Resources.Load<TextAsset> ("JsonUrl");
        jsonString = path.ToString ();
        var urlData = dataContent.CreateFromJson (jsonString).data;

        webSiteUrl = new string[] { "", "", "", "", "", "", "", "" };
        for (int i = 0; i < 8; i++) {
            WWW urlResponse = new WWW (urlData[i].imageUrl);
            yield return urlResponse;
            buttonList[i].texture = urlResponse.texture;
            webSiteUrl[i] = urlData[i].webUrl;
        }
    }

    [Serializable]
    public class dataContent {

        public List<Data> data;
        [Serializable]
        public class Data {
            public string imageUrl;
            public string webUrl;
        }
        public static dataContent CreateFromJson (string jsonString) {
            return JsonUtility.FromJson<dataContent> (jsonString);
        }
    }

    // Update is called once per frame
    void Update () {

    }

    public void onBtnPressed (int btn) {
        string webLink = webSiteUrl[btn];
        Application.OpenURL (webLink);
    }
}