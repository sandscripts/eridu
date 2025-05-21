using UnityEngine;

public class TileClickManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                Tile tile = hit.collider.GetComponent<Tile>();
                if (tile != null)
                {
                    tile.Highlight();
                }
            }
        }
    }
}

