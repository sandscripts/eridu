using UnityEngine;

public class Tile : MonoBehaviour
{
    private SpriteRenderer sr;
    private Color originalColor;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }

    public void Highlight()
    {
        Debug.Log($"Tile clicked: {gameObject.name}");
        sr.color = Color.green;
    }

    public void ResetColor()
    {
        sr.color = originalColor;
    }
}
