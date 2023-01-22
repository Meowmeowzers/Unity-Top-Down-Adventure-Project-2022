using System.Collections;
using TMPro;
using UnityEngine;

public class ShowFPS : MonoBehaviour
{
    private TextMeshProUGUI tm;

    private int fps;
    private float dtime = 0f;
    private WaitForSeconds wait;

    private void Awake()
    {
        tm = GetComponent<TextMeshProUGUI>();    
        wait = new(1f);
    }

    private void OnEnable()
    {
        StartCoroutine(FPS());
    }

    private IEnumerator FPS()
    {
        while (true)
        {
            dtime += (Time.deltaTime - dtime) * 0.1f;
            fps = (int)(1.0f / dtime);

            tm.text = "FPS: " + fps;
            yield return wait;
        }
    }
}