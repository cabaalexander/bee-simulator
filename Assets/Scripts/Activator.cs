using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour {

    bool active = false;
    GameObject note;
    string noteKey;
    private float h, v;

    private void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        if (active) {
            if (h < 0 && noteKey == "a" || h > 0 && noteKey == "d" || v < 0 && noteKey == "s" || v > 0 && noteKey == "w")
            {
                PlaySongGameManager.Instance.songScore++;
                Destroy(note);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        active = true;
        if (collision.gameObject.tag == "Note")
        {
            note = collision.gameObject;
            noteKey = note.GetComponent<Note>().key;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        active = false;
    }
}
