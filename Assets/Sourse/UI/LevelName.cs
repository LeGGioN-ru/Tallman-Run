using Lean.Localization;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class LevelName : MonoBehaviour
{
    private TMP_Text _levelName;

    private void Start()
    {
        _levelName = GetComponent<TMP_Text>();
        _levelName.text = $"{LeanLocalization.GetTranslationText("Level")} {GameSaver.GetCurrentSave().LevelNumber}";
    }
}