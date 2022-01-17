using UnityEngine;
using System.Net;
using  System.IO;
public class APIManager: MonoBehaviour
{
    public string GetCards() {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://140.143.149.188:8080/ftk?rid=9035");
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string messageJson = reader.ReadToEnd();
        // JsonUtility.FromJson<FTKCards>(messageJson);
        return messageJson;
    }
}
