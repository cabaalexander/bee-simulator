using System.Collections.Generic;
using UnityEngine;

public static class PlaySongGameManager {
    
    public static Dictionary<string, float> availableDanceKeys = new Dictionary<string, float> {
        { "w", 270 }, { "a", 0 }, { "s", 90 }, { "d", 180 }
    };

    public static int songScore = 0;

    public static void Reset() {
        songScore = 0;
    }

}
