using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D birdRigidbody;
    public float flapStrength;
    private LogicScript m_Logic;
    public bool birdIsAlive = true;
    public GameObject wing;
    public Sprite[] wings;
    private int wingIndex;
    private float m_actionTime;
    private float m_flapPeriod = 0.2f;
    private SpriteRenderer m_spriteRenderer;
    [SerializeField] private AudioManager m_audioManager;

    // Start is called before the first frame update
    void Start()
    {
        m_audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        m_spriteRenderer = wing.GetComponent<SpriteRenderer>();
        m_Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            birdRigidbody.velocity = Vector2.up * flapStrength;
            m_actionTime += Time.time;
            if (m_actionTime > m_flapPeriod)
            {
                m_actionTime -= m_flapPeriod;
                Flap();

            }
        }
        if (!birdRigidbody.velocity.Equals(Vector3.zero)) {
            birdRigidbody.transform.rotation = Quaternion.Euler(new Vector3(0,0,birdRigidbody.velocity.y));
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        m_Logic.GameOver();
        Debug.Log("Collided with pipe");
        birdIsAlive = false;
    }

    private void OnBecameInvisible()
    {
        m_Logic.GameOver();
        Debug.Log("Outside play screen");
        birdIsAlive = false;
    }

    void Flap()
    {
        m_spriteRenderer.sprite = wings[1];
        m_audioManager.PlaySFX(m_audioManager.sfx[(int)sfxNumber.FLAP]); // flap
        StartCoroutine(RevertToOriginalSprite());
    }
    
    IEnumerator RevertToOriginalSprite()
    {
        yield return new WaitForSeconds(0.1f); // Adjust the delay as needed
        m_spriteRenderer.sprite = wings[0];
    }
    
}
