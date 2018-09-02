using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class UiInteractionPositions : MonoBehaviour
{
    public List<LabelGui> objects = new List<LabelGui>();
    private float scaleFactor;
    private Canvas canvas;

    private Camera cam;

    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
        canvas = GetComponent<Canvas>();
        scaleFactor = canvas.scaleFactor;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (objects == null)
        {
            return;
        }
        objects.ForEach(x =>
        {
            Vector2 pos = x.transform.position;
            RectTransform CanvasRect = canvas.GetComponent<RectTransform>();
            // Vector2 viewportPoint = RectTransformUtility.WorldToLocalPoint(null, pos);

            Vector2 viewportPoint = RectTransformUtility.WorldToScreenPoint(null, pos);
            x.labelTransform.anchoredPosition = viewportPoint;

            // x.labelTransform.anchoredPosition = new Vector2(viewportPoint.x / scaleFactor, viewportPoint.y / scaleFactor);
            // Vector2 viewportPoint = Camera.main.ScreenToWorldPoint(pos);
            /*
            viewportPoint = new Vector2(
            ((viewportPoint.x * CanvasRect.sizeDelta.x) - (CanvasRect.sizeDelta.x * 0.5f)),
            ((viewportPoint.y * CanvasRect.sizeDelta.y) - (CanvasRect.sizeDelta.y * 0.5f)));

            x.labelTransform.anchoredPosition = new Vector2(viewportPoint.x / scaleFactor, viewportPoint.y / scaleFactor);
			*/
        });
    }
}
