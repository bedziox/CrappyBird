using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PipeSpawn : MonoBehaviour
{
    public GameObject pipe;
    private PipeMovement _pipeMovement;
    public float spawnTime;
    private float timer;
    public float hOffset;
    // Start is called before the first frame update
    void Start()
    {
        spawnTime = 2.5f;
        timer = 0;
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnTime)
        {
            timer += Time.deltaTime;
        }
        else
        {
            hOffset = Random.Range(2f, 3.25f);
            SpawnPipe();
            timer = 0;
        }

    }

    void SpawnPipe()
    {
        float lowestPoint = transform.position.y - hOffset;
        float highestPoint = transform.position.y + hOffset;
        GameObject spawnedPipe = Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
        spawnedPipe.GetComponent<PipeMovement>().moveSpeed +=
            spawnedPipe.GetComponent<PipeMovement>().increaseFactor * Time.time;
        spawnTime -= 0.01f;
    }

}
