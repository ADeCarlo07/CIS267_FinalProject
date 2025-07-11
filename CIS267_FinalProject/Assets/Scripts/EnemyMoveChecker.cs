using UnityEngine;

public class EnemyMoveChecker : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool moveChecker(Vector3 direction)
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(direction, 0.3f);


        for (int i = 0; i < hits.Length; i++)
        {
            HighlightBox tile = hits[i].GetComponent<HighlightBox>();
            if (tile != null && tile.highlighted)
            {
                return true;
            }
        }

        return false;
    }
}
