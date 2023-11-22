using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UIHelpers
{
    public static void SetCanvasGroup(CanvasGroup canvasGroup, bool value)
    {
        if (value)
        {
            canvasGroup.alpha = 1;
            canvasGroup.blocksRaycasts = true;
            canvasGroup.interactable = true;
        }
        else
        {
            canvasGroup.alpha = 0;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.interactable = false;
        }
    }

    public static void SetInteractableCanvasGroup(CanvasGroup canvasGroup, bool value)
    {
        if (value)
        {
            canvasGroup.blocksRaycasts = true;
            canvasGroup.interactable = true;
        }
        else
        {
            canvasGroup.blocksRaycasts = false;
            canvasGroup.interactable = false;
        }
    }
}
