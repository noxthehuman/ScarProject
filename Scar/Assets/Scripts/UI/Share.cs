using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Share : MonoBehaviour
{
    private string TWITTER_ADDRESS = "http://twitter.com/intent/tweet";
    private const string TWEET_LANGUAGE = "en";
    private string MESSENGER_ADDRESS = "https://facebook.com/new";

    public void ShareToFB(string linkParameter)
    {
        string nameParameter = "Look at my score on Scar !";//this is limited in text length 
        Application.OpenURL(MESSENGER_ADDRESS +
           "?text=" + UnityWebRequest.EscapeURL(nameParameter + "\n" + "Score :" + PlayerController.score.ToString() + "\n" +
           "Damage dealt :" + PlayerController.numberDamagesDealt.ToString() + "\n" + "Damage recieved :" + PlayerController.numberDamagesReceived.ToString()));
    }

    public void ShareToTW(string linkParameter)
    {
        string nameParameter = "Look at my score on Scar !";//this is limited in text length 
        Application.OpenURL(TWITTER_ADDRESS +
           "?text=" + UnityWebRequest.EscapeURL(nameParameter + "\n" + "Score :" + PlayerController.score.ToString() + "\n" +
           "Damage dealt :" + PlayerController.numberDamagesDealt.ToString() + "\n" + "Damage recieved :" + PlayerController.numberDamagesReceived.ToString() ));
    }

}
