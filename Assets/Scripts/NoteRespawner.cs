using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NoteRespawner : MonoBehaviour {

    public GameObject notePrefab;
    //public GameObject note
    public float secondsBetweenSpawn = 1.0f;
    public int stopAfter;
    public float speed = 1;
    public bool spawnLeft = false;
    public bool spawnRight = false;
    private int spawnCount;

    // Use this for initialization
    void Start () {
        StartCoroutine("SpawnNoteCoroutine");
	}

    private void Update()
    {
        if (spawnCount == stopAfter)
        {
            StopCoroutine("SpawnNoteCoroutine");
        }
    }

    void SpawnNote ()
    {
        int randomNumber = Mathf.RoundToInt(Random.Range(0.0f, PlaySongGameManager.availableDanceKeys.Count - 1));
        var notes = PlaySongGameManager.availableDanceKeys.Keys.ToList();
        var rotationZValue = PlaySongGameManager.availableDanceKeys.Values.ToList();
       
        string currentKey = notes[randomNumber];
        float currentRotationZValue = rotationZValue[randomNumber];
        Vector3 clonePosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Quaternion cloneRotation =  Quaternion.Euler(new Vector3(0, 0, currentRotationZValue));
        GameObject clone = Instantiate(notePrefab, clonePosition, cloneRotation);

        clone.gameObject.GetComponent<TransformX2D>().speed = speed;
        clone.gameObject.GetComponent<TransformX2D>().left = spawnLeft;
        clone.gameObject.GetComponent<TransformX2D>().right = spawnRight;

        clone.gameObject.GetComponent<Note>().key = currentKey;
        clone.gameObject.GetComponentInChildren<TextMesh>().text = currentKey;
    }

    IEnumerator SpawnNoteCoroutine ()
    {
        for (; ; )
        {
            spawnCount++;
            SpawnNote();
            yield return new WaitForSeconds(secondsBetweenSpawn);
        }
    }
}
