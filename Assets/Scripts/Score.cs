using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    public int score;

	void Update () {
        score = PlaySongGameManager.songScore;
	}
	
	
	void OnGUI () {
        gameObject.GetComponent<TextMesh>().text = score.ToString();
	}
}
