using UnityEngine;

using static UnityEngine.Random;

namespace DefaultNamespace
{
    public class CloudSpawn : MonoBehaviour
    {
        public GameObject cloud;
        public float spawnTime;
        public float hOffset;
        private float m_Time;

        // Start is called before the first frame update
        void Start()
        {
            spawnTime = 3f;
            m_Time = 0;
            SpawnCloud();
        }

        // Update is called once per frame
        void Update()
        {
            if (m_Time < spawnTime)
            {
                m_Time += Time.deltaTime;
            }
            else
            {
                hOffset = Range(-2f, 10f);
                SpawnCloud();
                m_Time = 0;
            }

        }

        void SpawnCloud()
        {
            float highestPoint = transform.position.y + hOffset;
            Instantiate(cloud, new Vector3(transform.position.x, Range(-3, highestPoint), 0), transform.rotation);
            cloud.transform.SetSiblingIndex(0);
        }
    }
}