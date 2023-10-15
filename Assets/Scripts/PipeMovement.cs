using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public float moveSpeed;
    public float despawnPosition = -20;
    public float increaseFactor = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < despawnPosition)
        {
            Debug.Log("Pipe despawned");
            Destroy(gameObject);
        }
        
    }
}
