using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySongGameManager : MonoBehaviour {

    private static PlaySongGameManager instance = null;
    
    public List<string> availableDanceKeys = new List<string> { "w", "a", "s", "d" };
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
