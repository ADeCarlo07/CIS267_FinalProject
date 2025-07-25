using UnityEngine;

public class creditsScroll : MonoBehaviour
{
    public RectTransform creditsPanel;
    public float scrollSpeed = 80f;
    void Start()
    {
        creditsPanel = GetComponent<RectTransform>();
    }
    void Update()
    {
        creditsPanel.anchoredPosition += new Vector2(0, scrollSpeed * Time.deltaTime);
    }
}
