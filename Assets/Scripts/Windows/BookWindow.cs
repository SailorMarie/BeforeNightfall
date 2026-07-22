using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;

public class BookWindow : Window
{
    [SerializeField] List<TextMeshProUGUI> m_quoteList;
    [SerializeField] float m_timeBetweenQuote = 3f;
    [SerializeField] float m_timeOfQuote = 3f;

   
    private void Start()
    {
        StartCoroutine(ShowQuote());
    }

    private IEnumerator ShowQuote()
    {
        yield return new WaitForSeconds(m_timeBetweenQuote);
        TextMeshProUGUI quote = m_quoteList[Random.Range(0, m_quoteList.Count)];
        while(quote.alpha != 1f)
        {
            yield return null;
            quote.alpha += 0.50f * Time.deltaTime;
            if(quote.alpha > 1f)
            {
                quote.alpha = 1f;
            }
        }
        StartCoroutine(HideQuote(quote));
    }

    private IEnumerator HideQuote(TextMeshProUGUI currentQuote)
    {
        yield return new WaitForSeconds(m_timeOfQuote);
        while (currentQuote.alpha != 0f)
        {
            yield return null;
            currentQuote.alpha -= 0.50f * Time.deltaTime;
            if (currentQuote.alpha < 0f)
            {
                currentQuote.alpha = 0f;
            }
        }
        StartCoroutine(ShowQuote());
    }
}
