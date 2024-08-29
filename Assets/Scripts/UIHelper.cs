using UnityEngine;
using UnityEngine.UI;

public static class UIHelper
{
    public static void AddButtonListener(GameObject parent, string buttonName, UnityEngine.Events.UnityAction action)
    {
        Button button = FindButton(parent, buttonName);
        if (button != null)
        {
            button.onClick.RemoveAllListeners(); // Đảm bảo không có sự kiện nào khác được gán trước đó
            button.onClick.AddListener(action);
        }
    }

    public static void SetButtonInteractable(GameObject parent, string buttonName, bool interactable)
    {
        Button button = FindButton(parent, buttonName);
        if (button != null)
        {
            button.interactable = interactable;
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

    public static void SetButtonText(GameObject parent, string buttonName, string text)
    {
        Button button = FindButton(parent, buttonName);
        if (button != null)
        {
            Text buttonText = button.GetComponentInChildren<Text>();
            if (buttonText != null)
            {
                buttonText.text = text;
            }
            else
            {
                Debug.LogWarning("Text component not found on " + buttonName);
            }
        }
    }

    public static void SetButtonColor(GameObject parent, string buttonName, Color color)
    {
        Button button = FindButton(parent, buttonName);
        if (button != null)
        {
            ColorBlock colorBlock = button.colors;
            colorBlock.normalColor = color;
            button.colors = colorBlock;
        }
    }

    private static Button FindButton(GameObject parent, string buttonName)
    {
        Transform buttonTransform = parent.transform.Find(buttonName);
        if (buttonTransform != null)
        {
            return buttonTransform.GetComponent<Button>() ?? buttonTransform.gameObject.AddComponent<Button>();
        }
        else
        {
            Debug.LogWarning("Button " + buttonName + " not found in " + parent.name);
            return null;
        }
    }
}
