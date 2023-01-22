using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int score = 0;
    private TextMeshProUGUI tm;

    private void Start()
    {
        tm = GetComponent<TextMeshProUGUI>();
    }

    private void FixedUpdate()
    {
        tm.text = "Score: " + score;
    }

    public void ScoreAdd(int number)
    {
        score += number;
        Debug.Log("Score plus " + number);
    }

    public void ScoreMinus(int number)
    {
        score -= number;
        Debug.Log("Score minus " + number);
    }
}