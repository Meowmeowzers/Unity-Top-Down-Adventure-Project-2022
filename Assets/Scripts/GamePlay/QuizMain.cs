using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuizMain : MonoBehaviour
{
    public List<QuizItem> items;
    public List<QuizItem> done;

    [SerializeField] private TextMeshProUGUI question;
    [SerializeField] private TextMeshProUGUI choice1;
    [SerializeField] private TextMeshProUGUI choice2;
    [SerializeField] private TextMeshProUGUI choice3;
    [SerializeField] private TextMeshProUGUI choice4;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI congratsText;
    [SerializeField] private TextMeshProUGUI scoreResultText;
    [SerializeField] private TextMeshProUGUI feedbackText;
    [SerializeField] private GameObject[] quizUI;
    [SerializeField] private GameObject[] resultsUI;

    private int currentIndex = 0;
    private int maxIndex;

    private int correctChoice;

    private int score;
    private int scoreMax;
    private int scoreHigh;

    private void Awake()
    {
        maxIndex = items.Count - 1;
        scoreMax = items.Count;
        scoreHigh = PlayerPrefs.GetInt("highScore");
    }

    private void OnEnable()
    {
        DisplayItem(0);
    }

    public void SelectChoice(int value)
    {
        Debug.Log("choice" + value);

        if(currentIndex == maxIndex)
        {
            CheckAnswer(value);
            EndQuiz();
        }
        else
        {
            CheckAnswer(value);
            currentIndex++;
            DisplayItem(currentIndex);
        }
    }

    public void DisplayItem(int index)
    {
        items[index].MakeChoices();
        question.text = items[index].question;
        choice1.text = items[index].selectedChoices[0];
        choice2.text = items[index].selectedChoices[1];
        choice3.text = items[index].selectedChoices[2];
        choice4.text = items[index].selectedChoices[3];
        scoreText.text = score.ToString() + " / " + scoreMax;
        correctChoice = items[index].randomCorrectAnswerIndex;
    }

    public void CheckAnswer(int answer)
    {
        if(answer == correctChoice)
        {
            score++;
        }
    }

    private void EndQuiz()
    {
        ProcessResults();
        for(int i = 0; i < quizUI.Length; i++)
        {
            quizUI[i].SetActive(false);
        }
        for (int i = 0; i < resultsUI.Length; i++)
        {
            resultsUI[i].SetActive(true);
        }
    }

    private void ProcessResults()
    {
        PlayerPrefs.SetInt("highScore", score);

        scoreResultText.text = "Your final score is " + score + " / " + scoreMax;
        
        if(score <= (scoreMax * 0.1f))
        {
            feedbackText.text = "La na finish na, drop na...";
        }
        else if (score <= (scoreMax * 0.3f))
        {
            feedbackText.text = "You got low scores, you should try again :(";
        }
        else if (score <= (scoreMax * 0.6f))
        {
            feedbackText.text = "You did well, aim for a higher score...";
        }
        else if (score < scoreMax)
        {
            feedbackText.text = "You did great, you should aim for a perfect score...";
        }
        else if (score == scoreMax)
        {
            feedbackText.text = "You achieved a perfect score!!!";
        }
    }

    public void BackToMainMenu()
    {
        for (int i = 0; i < quizUI.Length; i++)
        {
            quizUI[i].SetActive(true);
        }
        for (int i = 0; i < resultsUI.Length; i++)
        {
            resultsUI[i].SetActive(false);
        }
        ResetQuiz();
        CameraFind.Instance.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public void ResetQuiz()
    {
        score = 0;
        currentIndex = 0;
        scoreHigh = PlayerPrefs.GetInt("highScore");
    }

}
