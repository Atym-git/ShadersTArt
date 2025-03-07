using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCube : MonoBehaviour
{
    private Renderer cubeRenderer;

    private int shaderBoolValue;

    private string[] shaderFloatKeys = {"", "", ""};

    private const string shaderBool = "_IsActive";

    private void Awake()
    {
        cubeRenderer = GetComponent<Renderer>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && shaderBoolValue == 0)
        {
            shaderBoolValue = 1;
            cubeRenderer.material.SetFloat(shaderBool, shaderBoolValue);
        }
        else if (Input.GetMouseButtonDown(0) && shaderBoolValue == 1)
        {
            shaderBoolValue = 0;
            cubeRenderer.material.SetFloat(shaderBool, shaderBoolValue);
        }
    }
}
