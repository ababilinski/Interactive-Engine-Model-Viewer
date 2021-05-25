using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class DataPointScale : MonoBehaviour
{
    [SerializeField] private Image fill;

    [SerializeField] private TextMeshProUGUI outputTextMesh;

    [SerializeField] private TextMeshProUGUI unitTextMesh;



    [SerializeField] private float maxValue;

    public void UpdateValue(float value)
    {
        fill.fillAmount = value/ maxValue;
        outputTextMesh.text = value.ToString("F1");
    }

    public void Init(string unitText, float max)
    {
        if (max > 0)
        {
            maxValue = max;
        }
        unitTextMesh.text = unitText;
    }
}
