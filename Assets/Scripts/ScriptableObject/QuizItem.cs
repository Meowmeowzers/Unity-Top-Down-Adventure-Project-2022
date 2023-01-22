using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "CustomAsset/QuizItemData")]
public class QuizItem : ScriptableObject
{
	[TextArea(5,10)]
    public string question = "Insert Question";

	[TextArea(2,4)]
    public string rightChoice = "Right Answer";
    public string[] otherChoices = new string[4];

    public string[] selectedChoices = new string[4];

    public int randomCorrectAnswerIndex;

    public void MakeChoices()
    {
        randomCorrectAnswerIndex = Random.Range(0, selectedChoices.Length);
        Debug.Log("Correct answer is " + randomCorrectAnswerIndex);

        for (int i = 0; i < selectedChoices.Length; i++)
        {
            if(i == randomCorrectAnswerIndex)
            {
                selectedChoices[i] = rightChoice;
            }
            else
            {
                selectedChoices[i] = otherChoices[i];
            }
        }
    }


    
}

/*
 public static void Shuffle(string[] list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    } 
 
private static Random rng = new Random();

public static void Shuffle<T>(this IList<T> list)
{
    int n = list.Count;
    while (n > 1)
    {
        n--;
        int k = rng.Next(n + 1);
        T value = list[k];
        list[k] = list[n];
        list[n] = value;
    }
}
*/
