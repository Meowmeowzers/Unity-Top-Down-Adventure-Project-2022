using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private GameManager gameManager;
    //private Vector2 positionCheckPoint;
    private CurrentGameState gameState;
    [SerializeField] private PortalCoordinates coordinate;

    private AudioSource audioSource;
    //private bool isActive = false;

    [SerializeField] private AudioClip soundCheckPoint;

    private void Start()
    {
        //positionCheckPoint = transform.position;
        audioSource = GetComponent<AudioSource>();
        gameManager = GameManager.Instance;
        gameState = FindObjectOfType<CurrentGameState>();
    }

    private void Update()
    {
        if (gameState == null)
        {
            gameState = FindObjectOfType<CurrentGameState>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerStats>())
        {
            //isActive = true;
            Debug.Log("Check point activated at: " + transform.position);
            audioSource.PlayOneShot(soundCheckPoint);
            gameState.playerTransform.x = coordinate.position.x;
            gameState.playerTransform.y = coordinate.position.y;
            gameState.GetAllCurrentData();
            gameState.SaveCurrentGameState();
        }
    }
}