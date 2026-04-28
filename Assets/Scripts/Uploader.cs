using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Uploader : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Upload());
    }

    IEnumerator Upload()
    {
        PlayerActions p1 = new PlayerActions("oui", 150, 30, "1");
        List<PlayerActions> playerActions = new();
        playerActions.Add(p1);
        string payload = "{\"records\":[{\"fields\":"+JsonUtility.ToJson(p1)+"}]}";
        string uri = "https://docs.getgrist.com/api/docs/redacted/tables/PlayerActions/records";
        using UnityWebRequest www = UnityWebRequest.Post(uri, payload, "application/json");
        www.SetRequestHeader("Content-Type", "application/json");
        www.SetRequestHeader("Authorization", "redacted");
        Debug.Log(www.uploadHandler.data);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
        Debug.Log(www.downloadHandler.text);
    }
}

[Serializable]
public class PlayerActions
{
    public string Player_ID;
    public int Hits;
    public int Jumps;
    public string Game_ID;

    public PlayerActions(string player_ID, int hits, int jumps, string game_ID)
    {
        Player_ID = player_ID;
        Hits = hits;
        Jumps = jumps;
        Game_ID = game_ID;
    }
}