using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorToUse : MonoBehaviour
{
    public float ColorValue_R, ColorValue_G, ColorValue_B;
    public Color ColorMade;

    void Update()
    {
        var ColorRenderer = gameObject.GetComponent<Renderer>();
        ColorMade = new Color(ColorValue_R, ColorValue_G, ColorValue_B, 0f);
        ColorRenderer.material.SetColor("_Color", ColorMade);
    }
}
