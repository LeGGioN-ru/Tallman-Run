using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class LevelName : MonoBehaviour
{
    private TMP_Text _levelName;

    void Start()
    {
        _levelName = GetComponent<TMP_Text>();
        _levelName.text = SceneManager.GetActiveScene().name;
    }
}