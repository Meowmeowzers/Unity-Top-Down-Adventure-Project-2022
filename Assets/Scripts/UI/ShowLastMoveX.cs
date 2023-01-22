using TMPro;
using UnityEngine;

public class ShowLastMoveX : MonoBehaviour
{
    [SerializeField] private Movement movement;
    private TextMeshProUGUI tm;

    private void Start()
    {
        tm = GetComponent<TextMeshProUGUI>();
    }

    private void FixedUpdate()
    {
        tm.text = "Last Move X: " + movement.LastMoveX;
    }
}