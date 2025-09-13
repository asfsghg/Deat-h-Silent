using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIPanelAnimator : MonoBehaviour
{
    public RectTransform panel;         // Панель (RectTransform)
    public CanvasGroup canvasGroup;     // Для прозрачности

    [Header("Positions")]
    public Vector2 hiddenPosition;      // Позиция, где панель скрыта
    public Vector2 shownPosition;       // Позиция, где панель показывается

    [Header("Sizes")]
    public Vector2 hiddenSize = new Vector2();   // Размер в скрытом состоянии
    public Vector2 shownSize = new Vector2(0.5958308f,1.121955f); // Размер при показе

    [Header("Animation")]
    public float duration = 0.5f;       // Время анимации

    private bool isVisible = false;

    void Start()
    {
        if (canvasGroup == null)
            canvasGroup = panel.gameObject.AddComponent<CanvasGroup>();

        // Начальное состояние
        panel.anchoredPosition = hiddenPosition;
        panel.sizeDelta = hiddenSize;
        canvasGroup.alpha = 0;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
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
        float time = 0f;

        Vector2 startPos = panel.anchoredPosition;
        Vector2 endPos = shownPosition;

        Vector2 startSize = panel.sizeDelta;
        Vector2 endSize = shownSize;

        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;

            panel.anchoredPosition = Vector2.Lerp(startPos, endPos, t);
            panel.sizeDelta = Vector2.Lerp(startSize, endSize, t);
            canvasGroup.alpha = Mathf.Lerp(0, 1, t);

            yield return null;
        }

        panel.anchoredPosition = endPos;
        panel.sizeDelta = endSize;
        canvasGroup.alpha = 1;
    }

    IEnumerator HidePanel()
    {
        float time = 0f;

        Vector2 startPos = panel.anchoredPosition;
        Vector2 endPos = hiddenPosition;

        Vector2 startSize = panel.sizeDelta;
        Vector2 endSize = hiddenSize;

        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;

            panel.anchoredPosition = Vector2.Lerp(startPos, endPos, t);
            panel.sizeDelta = Vector2.Lerp(startSize, endSize, t);
            canvasGroup.alpha = Mathf.Lerp(1, 0, t);

            yield return null;
        }

        panel.anchoredPosition = endPos;
        panel.sizeDelta = endSize;
        canvasGroup.alpha = 0;
    }
}



    