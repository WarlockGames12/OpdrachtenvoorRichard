using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuildUI : MonoBehaviour
{
    [SerializeField] public RectTransform _MenuPanel;

    private void Start()
    {
        Show(false);
    }

    public void Show(bool enabled)
    {
        _MenuPanel.gameObject.SetActive(enabled);
    }
}
