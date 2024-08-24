using System;
using UnityEngine;
using UnityEngine.UI;

public static class UIHelper
{
    public static void AddButtonListener(GameObject parent, string buttonName, Action action)
    {
        Transform buttonTransform = parent.transform.Find(buttonName);
        if (buttonTransform != null)
        {
            GameObject buttonObject = buttonTransform.gameObject;
            if (buttonObject.GetComponent<Button>() == null)
            {
                buttonObject.AddComponent<Button>();
            }
            Button button = buttonObject.GetComponent<Button>();
            button.onClick.AddListener(() => action());
        }
        else
        {
            Debug.Log($"{buttonName} not found");
        }
    }
}
