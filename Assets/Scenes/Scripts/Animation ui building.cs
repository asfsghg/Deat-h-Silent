using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIPanelAnimator : MonoBehaviour
{
    public RectTransform panel;         
    public CanvasGroup canvasGroup;  

    [Header("Positions")]
    [Header("Sizes")]


    [Header("Animation")]
    public float duration = 0.5f; 

    private bool isVisible = false;

    void Start()
    {
        if (canvasGroup == null)
            canvasGroup = panel.gameObject.AddComponent<CanvasGroup>();


        canvasGroup.alpha = 0;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            
            TogglePanel();
        }
    }

    public void TogglePanel()
    {
        if (isVisible)
            StartCoroutine(HidePanel());
        else
            StartCoroutine(ShowPanel());

        isVisible = !isVisible;
    }

    IEnumerator ShowPanel()
    {
        Cursor.lockState = CursorLockMode.None;

        float time = 0f;

        Vector2 startPos = panel.anchoredPosition;


        Vector2 startSize = panel.sizeDelta;


        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;

            canvasGroup.alpha = Mathf.Lerp(0, 1, t);

            yield return null;
        }


        canvasGroup.alpha = 1;
    }

    IEnumerator HidePanel()
    {
        Cursor.lockState = CursorLockMode.Locked;

        float time = 0f;

        Vector2 startPos = panel.anchoredPosition;


        Vector2 startSize = panel.sizeDelta;


        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;


            canvasGroup.alpha = Mathf.Lerp(1, 0, t);

            yield return null;
        }


        canvasGroup.alpha = 0;
    }
}



    