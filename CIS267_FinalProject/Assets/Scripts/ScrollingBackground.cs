using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    //Probably don't use numbers above 1 for these (too fast)
    //use negative value for opposite directional scrolling
    public float speedHorizontal;
    public float speedVertical;

    [SerializeField]
    private Renderer bgRenderer;

    void Update()
    {
        bgRenderer.material.mainTextureOffset += new Vector2(speedHorizontal * Time.deltaTime, speedVertical * Time.deltaTime);
    }
}
