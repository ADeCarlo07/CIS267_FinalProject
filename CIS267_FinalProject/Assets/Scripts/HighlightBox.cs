using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class HighlightBox : MonoBehaviour
{

    private float destroyDelay = 0.05f;
    private float timeUnhighlighted;
    public bool highlighted;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        highlighted = true;
    }
    void Update()
    {
        if (!highlighted)
        {
            timeUnhighlighted += Time.deltaTime;
            if (timeUnhighlighted >= destroyDelay)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            timeUnhighlighted = 0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerControllerOnGrid.inMovementBounds = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerControllerOnGrid.inMovementBounds = false;
        }
    }
}
