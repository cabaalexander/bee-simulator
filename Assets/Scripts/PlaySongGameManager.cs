using System.Collections.Generic;
using UnityEngine;

public static class PlaySongGameManager {
    
    public static readonly List<string> availableDanceKeys = new List<string> { "w", "a", "s", "d" };
    public static int songScore = 0;

    public static void Reset() {
        songScore = 0;
    }

}
