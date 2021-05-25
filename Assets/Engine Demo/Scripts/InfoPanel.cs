using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour
{


    [SerializeField] private LookAtConstraint lookAtConstraint;

    private void Awake()
    {
        lookAtConstraint.constraintActive = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
