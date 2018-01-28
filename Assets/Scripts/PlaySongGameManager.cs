using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySongGameManager : MonoBehaviour {

    private static PlaySongGameManager instance = null;

    public Dictionary<string, float> availableDanceKeys = new Dictionary<string, float> {
        { "w", 270 }, { "a", 0 }, { "s", 90 }, { "d", 180 }
    };
    public int songScore = 0;

    public static PlaySongGameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.Find("PlaySongGameController").GetComponent<PlaySongGameManager>();
            }
            return instance;
        }
    }
}
