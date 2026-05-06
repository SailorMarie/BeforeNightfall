using UnityEngine;
using UnityEngine.UI;

public class SanitySliderWindow : Window
{
    [SerializeField] private Slider m_sanitySlider;
    public void SetSanity(float sanity)
    {
        m_sanitySlider.value = sanity;
    }
}
