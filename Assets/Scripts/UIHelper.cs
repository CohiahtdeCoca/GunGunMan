using UnityEngine;
using UnityEngine.UI;

public static class UIHelper
{
    public static void AddButtonListener(GameObject parent, string buttonName, UnityEngine.Events.UnityAction action)
    {
        Transform buttonTransform = parent.transform.Find(buttonName);
        if (buttonTransform != null)
        {
            Button button = buttonTransform.GetComponent<Button>() ?? buttonTransform.gameObject.AddComponent<Button>();
            button.onClick.AddListener(action);
        }
        else
        {
            Debug.LogWarning("Button " + buttonName + " not found in " + parent.name);
        }
    }

    public static void SetButtonInteractable(GameObject parent, string buttonName, bool interactable)
    {
        Transform buttonTransform = parent.transform.Find(buttonName);
        if (buttonTransform != null)
        {
            Button button = buttonTransform.GetComponent<Button>();
            if (button != null)
            {
                button.interactable = interactable;
            }
            else
            {
                Debug.LogWarning("Button component not found on " + buttonName);
            }
        }
        else
        {
            Debug.LogWarning("Button " + buttonName + " not found in " + parent.name);
        }
    }

    public static void SetButtonSprite(GameObject parent, string buttonName, Sprite sprite)
    {
        Transform buttonTransform = parent.transform.Find(buttonName);
        if (buttonTransform != null)
        {
            Image buttonImage = buttonTransform.GetComponent<Image>();
            if (buttonImage != null)
            {
                buttonImage.sprite = sprite;
            }
            else
            {
                Debug.LogWarning("Image component not found on " + buttonName);
            }
        }
        else
        {
            Debug.LogWarning("Button " + buttonName + " not found in " + parent.name);
        }
    }
}
