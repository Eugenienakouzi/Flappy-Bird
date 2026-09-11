using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPipe : MonoBehaviour
{
    public GameObject topColumn;
    public GameObject bottomColumn;
    public GameObject stopPipe;
    public GameObject score;

    public float spawnInterval;

    public float minHeight;
    public float maxHeight;
    public float minGap;
    public float maxGap;

    public float spawnXPosition;

    public float columnSpeed;

    public Transform bird;

    void Start()
    {
        StartCoroutine(SpawnColumns());
    }

    void Update()
    {
        if (stopPipe.GetComponent<JumpBird>().play == true)
        {
            foreach (Transform child in transform)
            {
                child.position += Vector3.left * columnSpeed * Time.deltaTime;
                if (child.position.x < -5f)
                {
                    Destroy(child.gameObject);
                }
            }
        }
        else {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

        }
    }

    IEnumerator SpawnColumns()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            float randomHeight = Random.Range(minHeight, maxHeight);
            float randomGap = Random.Range(minGap, maxGap);

            Vector3 topPosition = new Vector3(spawnXPosition, randomHeight + randomGap / 2, 0);
            Vector3 bottomPosition = new Vector3(spawnXPosition, randomHeight - randomGap / 2, 0);
        
            if(stopPipe.GetComponent<JumpBird>().play == true)
            {
                GameObject newTopColumn = Instantiate(topColumn, topPosition, Quaternion.identity);
                GameObject newBottomColumn = Instantiate(bottomColumn, bottomPosition, Quaternion.identity);
                newTopColumn.transform.SetParent(transform);
                newBottomColumn.transform.SetParent(transform);

                GameObject newDetection = Instantiate(score, topPosition, Quaternion.identity);
                newDetection.transform.SetParent(transform);

            }



        }
    }
}