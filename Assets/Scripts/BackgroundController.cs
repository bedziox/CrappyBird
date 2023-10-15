using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class BackgroundController : MonoBehaviour
    {
        [Range(0f,1f)]
        public float scrollSpeed = 0.1f;
        private Material backgroundMaterial;
        public float repeatWidth = 10.0f; // Adjust this to the width of your background
        private Vector2 offset;

        private void Start()
        {
            backgroundMaterial = GetComponent<Renderer>().material;
            GetComponent<Renderer>().sortingOrder = -5;
            offset = Vector2.zero;
        }
        private void Update()
        {
            // Scroll the background
            offset.x += scrollSpeed * Time.deltaTime;
            if (offset.x > repeatWidth)
            {
                offset.x -= repeatWidth;
            }

            // Apply the offset to the material
            backgroundMaterial.mainTextureOffset = offset;
        }
    }
}