using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    TextMeshPro label;

    void Awake() //Awake  è letteralmente la prima cosa che viene fatta
    {
        label = GetComponent<TextMeshPro>();
    }

    void Update()
    {
        if(!Application.isPlaying)
        {

        }
    }
}
