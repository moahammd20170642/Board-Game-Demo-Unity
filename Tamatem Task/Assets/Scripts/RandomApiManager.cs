using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class RandomApiManager : MonoBehaviour
{
    public int CurrentRandomNumber;
    public class Parameter
    {
        [JsonProperty("request_id")]
        public int RequestId { get; set; }

        [JsonProperty("min")]
        public int Min { get; set; }

        [JsonProperty("max")]
        public int Max { get; set; }
                                                                            //API Responce Data  .....Converted from Json To C# Code    

        [JsonProperty("num")]
        public int Num { get; set; }

        [JsonProperty("unique")]
        public int Unique { get; set; }
    }

    public class Response
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("parameters")]
        public List<Parameter> Parameters { get; set; }

        [JsonProperty("values")]
        public List<int> Values { get; set; }
    }





    void Awake()
    {
        CurrentRandomNumber = -1;    /// to know if the api request still not complete or faild

        // Start the API call On Awake to make Sure we have one random number when the GetCurrentRandomNumber() is called 
        RequestNewRandomNumber();
    }

    IEnumerator GetRandomNumber()
    {
        using UnityWebRequest webRequest = UnityWebRequest.Get("https://csrng.net/csrng/csrng.php?key=a04004479f0ef302&min=1&max=6&num=1");
        yield return webRequest.SendWebRequest();


        if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Error: " + webRequest.error);

            CurrentRandomNumber = -1;      // -1 mean the api request faild 
            //DisconnectedrText.text.;
        }
        else
        {
            // Deserialize the JSON response into the Response class
            List<Response> responses = JsonConvert.DeserializeObject<List<Response>>(webRequest.downloadHandler.text);

            // Access the random numbers
            foreach (var response in responses)
            {
              
                if (response.Values != null)
                {
                    CurrentRandomNumber = response.Values[0];
                    //Debug.Log("current API CAll "+ CurrentRandomNumber);
                }
            }


            webRequest.Dispose();

        }
    }


    public void RequestNewRandomNumber()
    {
        StartCoroutine(GetRandomNumber());
    }


   
    public int GetCurrentRandomNumber()
    {
        RequestNewRandomNumber();                   //////////refresh the random call , on verytime we called GetCurrentRandomNumber() 

        return CurrentRandomNumber;
    }

}
