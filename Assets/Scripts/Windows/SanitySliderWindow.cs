using UnityEngine;
using UnityEngine.UI;

public class SanitySliderWindow : Window
{
    [SerializeField] private Slider m_sanitySlider;

    private void Start()
    {
        LevelManager.Instance.OnGameEnd += Close;
    }
    public void SetSanity(float sanity)
    {
        m_sanitySlider.value = sanity;
    }
}
