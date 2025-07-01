using UnityEngine;

public class PlayerMovementRadius : MonoBehaviour
{

    public GameObject highlightedBox;
    private GameObject createdHighlightBox;

   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MovementRadius"))
        {
            createdHighlightBox = Instantiate(highlightedBox, transform.position, Quaternion.identity);
            createdHighlightBox.GetComponent<HighlightBox>().highlighted = true;
         
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MovementRadius"))
        {

            if (createdHighlightBox != null)
            {
                createdHighlightBox.GetComponent<HighlightBox>().highlighted = false;
            }
        }
            
    }
}
