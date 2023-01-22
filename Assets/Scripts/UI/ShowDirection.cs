using TMPro;
using UnityEngine;

public class ShowDirection : MonoBehaviour
{
    [SerializeField] private Movement movement;
    private TextMeshProUGUI tm;

    private void Start()
    {
        tm = GetComponent<TextMeshProUGUI>();
    }

    private void FixedUpdate()
    {
        tm.text = "Direction: " + movement.ldirection;
    }
}