using Cinemachine;
using UnityEngine;

public class CameraFind : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cinemachineCamera;

    private static CameraFind instance = null;

    public static CameraFind Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        instance = this;
        cinemachineCamera = GetComponentInChildren<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        if (cinemachineCamera.Follow == null)
        {
            cinemachineCamera.Follow = GameManager.Instance.FindPlayerObject().transform;
        }
    }
}

/*

if (cinemachineCamera.Follow == null || gameManager == null)
        {
            gameManager = FindObjectOfType<GameManager>();
            cinemachineCamera = GetComponentInChildren<CinemachineVirtualCamera>();
            Debug.Log("Target Player Found, Camera Following");
        }

*/