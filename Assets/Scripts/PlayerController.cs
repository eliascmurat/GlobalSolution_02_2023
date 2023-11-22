using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Sprite spriteFeliz;
    public Sprite spriteNeutro;
    public Sprite spriteTriste;
    
    public void ChangeSprite(int notaFinal)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (notaFinal >= 9)
        {
            spriteRenderer.sprite = spriteFeliz;
        }
        else if (notaFinal >= 7)
        {
            spriteRenderer.sprite = spriteNeutro;
        }
        else if (notaFinal >= 0)
        {
            spriteRenderer.sprite = spriteTriste;
        }
    }
}
