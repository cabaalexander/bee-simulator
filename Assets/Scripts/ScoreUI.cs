using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour {

    Text text;
    private void Start()
    {
        text = gameObject.GetComponent<Text>();
    }
    private void OnGUI()
    {
        text.text = PlaySongGameManager.songScore.ToString();
    }
}
