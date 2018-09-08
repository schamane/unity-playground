using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Unity tip"
// Usually it is desired that the HUD canvas is separated from Camera effects, or "ScreenSpaceOverlay" mode
// But Overlay canvases are terrible to work with
// So keep your canvas in "Screen Space Camera", and switch it automatically to Overlay when the game starts

public class CanvasRenderModeSwitcher : MonoBehaviour
{
    public RenderMode newRenderMode = RenderMode.ScreenSpaceOverlay;

    void Start()
    {
        Canvas canvas = GetComponent<Canvas>();
        if (canvas != null)
            canvas.renderMode = newRenderMode;
    }
}