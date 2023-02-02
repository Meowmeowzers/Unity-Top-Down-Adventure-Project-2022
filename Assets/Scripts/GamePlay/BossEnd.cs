using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnd : MonoBehaviour
{
    public void StartEndSequence()
    {
        StartCoroutine(CEndSequence());
    }

    private IEnumerator CEndSequence()
    {
        //gameObject.SetActive(false);
        //Debug.Log("Boss is Defeated");
        yield return new WaitForSeconds(2f);
        GameManager.HideGameControlsUI();
        
        yield return new WaitForSeconds(1f);
        SceneLoader.LoadScene("FinalQuiz");

        yield break;
    }
}
