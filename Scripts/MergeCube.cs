using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MergeCube : MonoBehaviour
{
    public TMP_Text[] texts;

    [SerializeField]
    private CubeCollection cube;

    private void Start()
    {
        cube = GetComponent<CubeCollection>();
    }

    private void Update()
    {
        
        foreach (var i in texts)
        {
            i.text = cube.num.ToString();
        }
    }
}
