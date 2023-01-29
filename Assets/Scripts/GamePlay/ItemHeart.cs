using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHeart : MonoBehaviour
{
    [SerializeField] private float healAmount = 5f;
    [SerializeField] private AudioClip sound;

    private AudioSource audioSource;
    private SpriteRenderer sr;
    private WaitForSeconds wait;

    private bool isReady = true;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
        wait = new WaitForSeconds(1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerStats>() && isReady)
        {
            collision.gameObject.GetComponent<PlayerStats>().ModifyHP(healAmount);
            isReady = false;
            audioSource.PlayOneShot(sound);
            sr.sprite = null;
            StartCoroutine(Destroy());
        }
    }

    private IEnumerator Destroy()
    {
        yield return wait;
        Destroy(gameObject);
    }
}
