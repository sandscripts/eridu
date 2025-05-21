using UnityEngine;

public class TileClickManager : MonoBehaviour
{
    public bool buildMode = false;
    void Update()
    {
          if (Input.GetKeyDown(KeyCode.B))
        {
            buildMode = !buildMode;
            Debug.Log("Build mode: " + (buildMode ? "ON" : "OFF"));
        }
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                Tile tile = hit.collider.GetComponent<Tile>();
                if (tile != null)
                {
                     if (buildMode)
                        tile.PlaceBuilding();
                    else
                    tile.Highlight();
                }
            }
        }
    }
}

