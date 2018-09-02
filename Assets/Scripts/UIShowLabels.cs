using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShowLabels : MonoBehaviour
{
    public Text textPrefab;

    UiInteractionPositions ui;
    Canvas canvas;

    // Use this for initialization
    void Awake()
    {
        canvas = GameObject.Find("UI Interaction").GetComponent<Canvas>();
        Debug.Log(canvas);
        ui = canvas.GetComponent<UiInteractionPositions>();
        Debug.Log(ui);
    }

    void OnTriggerEnter(Collider other)
    {
        var x = other.GetComponent<InteractionUIData>();
        if (x != null)
        {
            ui.objects.Add(this.instanciateLabel(x, other.gameObject));
            Debug.Log("Attach Object: " + other.gameObject.name);
        }
    }

    void OnTriggerExit(Collider other)
    {
        ui.objects.RemoveAll(s =>
        {
            if (s.source == other.gameObject)
            {
                Destroy(s.label.gameObject);
                return true;
            }
            return false;
        });
    }

    LabelGui instanciateLabel(InteractionUIData data, GameObject source)
    {
        Text text = Instantiate(textPrefab, canvas.transform.position, Quaternion.identity) as Text;// GetComponentInChildren<Text>();
        text.transform.SetParent(canvas.transform, false);
        text.text = data.DisplayName;
        return new LabelGui
        {
            label = text,
            labelTransform = text.GetComponent<RectTransform>(),
            source = source,
            transform = source.transform
        };
    }
}
