using UnityEngine;

namespace DefaultNamespace
{
    public class CloudMovement : MonoBehaviour
    {
        public float moveSpeed = 3;
        public float despawnPosition = -20;
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
                Debug.Log("Cloud despawned");
                Destroy(gameObject);
            }
        }
    }
}