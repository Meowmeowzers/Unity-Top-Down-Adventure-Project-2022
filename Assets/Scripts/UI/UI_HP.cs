using TMPro;
using UnityEngine;

public class UI_HP : MonoBehaviour
{
    private PlayerStats player;
    private TextMeshProUGUI tm;

    private void Start()
    {
        player = FindObjectOfType<PlayerStats>();
        tm = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerStats>();
        }
        tm.text = "HP: " + player.ObjectHP;
    }
}