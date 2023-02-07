using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveEraser : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }
}
