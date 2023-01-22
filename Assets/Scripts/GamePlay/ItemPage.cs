using UnityEngine;

public class ItemPage : MonoBehaviour
{
    [SerializeField] private uint pageNumber;
    [SerializeField] private AudioClip soundPickUp;
    private AudioSource audioSource;
    private SpriteRenderer sr;
    private bool isUsed = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerStats>() != null && !isUsed)
        {
            //Debug.Log("collided " + collision);
            audioSource.PlayOneShot(soundPickUp);
            FindObjectOfType<MainSystem>().GetComponentInChildren<ScrollMainData>().UnlockBookPage(pageNumber);
            sr.sprite = null;
            isUsed = true;
            Destroy(gameObject, 0.5f);
        }
    }
}