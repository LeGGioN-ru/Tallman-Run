using CartoonFX;
using Lean.Localization;
using UnityEngine;

[RequireComponent(typeof(CFXR_ParticleText))]
public class ParticleTextLocalization : MonoBehaviour
{
    private CFXR_ParticleText _particleText;

    private void Start()
    {
        _particleText = GetComponent<CFXR_ParticleText>();
        string text = LeanLocalization.GetTranslationText("WOW");
        _particleText.UpdateText(text);
    }
}
