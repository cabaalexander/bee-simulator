using UnityEngine;
using System.Collections;

public class Flower : MonoBehaviour
{
    public int setScore;
    private bool hasPollen = true;
    private GameObject pollen;

    private void Start()
    {
        pollen = transform.Find("flower polem").gameObject;
    }

    public void GotPollen()
    {
        if (hasPollen)
        {
            hasPollen = false;
            pollen.SetActive(false);
            PlaySongGameManager.songScore += setScore;
        }
    }
}
