using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinChangersLoader : MonoBehaviour
{
    private SkinChanger[] _skinChanges;

    private void Awake()
    {
        _skinChanges = GetComponentsInChildren<SkinChanger>();
    }

    public void Execute(IReadOnlyList<int> openedButtons)
    {

    }
}
