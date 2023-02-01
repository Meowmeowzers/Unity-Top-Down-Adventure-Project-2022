using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextPulse : MonoBehaviour
{
    private TextMeshProUGUI text;
    private WaitForSeconds wait;
    private float opacity = 1f;

    [SerializeField] private float strength = .2f;
    private float appliedStrength;
    [SerializeField] private float tickSpeed = .05f;
    [SerializeField] private float max = 1f;
    [SerializeField] private float min = .3f;

    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        wait = new WaitForSeconds(tickSpeed);
        opacity = text.color.a;
        appliedStrength = strength;
    }

    private void OnEnable()
    {
        StartCoroutine(CStartPulse());
    }

    private void OnDisable()
    {
        text.color = new(text.color.r, text.color.g, text.color.b, 1f);
        StopAllCoroutines();
    }

    private IEnumerator CStartPulse()
    {
        while (true)
        {

            opacity += appliedStrength;
            text.color = new(text.color.r, text.color.g, text.color.b, opacity);

            if (text.color.a <= min)
            {
                appliedStrength = strength;
            }
            else if (text.color.a >= max)
            {
                appliedStrength = -(strength);
            }
            else { }
            

            yield return wait;
        }
    }
}
