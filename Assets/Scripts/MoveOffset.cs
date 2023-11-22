using UnityEngine;

public class MoveOffset : MonoBehaviour
{
    private Material material;
    public float speed = 1.5f;
    private float offset;
    
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    void FixedUpdate()
    {
        offset += 0.001f;
        material.SetTextureOffset("_MainTex", new Vector2(offset * speed, 0));
    }
}
