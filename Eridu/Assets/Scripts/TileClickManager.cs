using UnityEngine;
using TMPro;
[System.Serializable]
public class BuildingType
{
    public List<BuildingType> buildingTypes;
    private int selectedIndex = 0;
    private GameObject activePreview;
    public string name;
    public GameObject buildingPrefab;
    public GameObject previewPrefab;
}
public class TileClickManager : MonoBehaviour
{
    public bool buildMode = false;
    public TextMeshProUGUI buildModeText;
    public GameObject previewPrefab;
    private GameObject activePreview;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            buildMode = !buildMode;
            Debug.Log("Build mode: " + (buildMode ? "ON" : "OFF"));
            if (buildModeText != null)
            {
                buildModeText.text = "Build Mode: " + (buildMode ? "ON" : "OFF");
            }
        }
        if (buildMode)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                Tile tile = hit.collider.GetComponent<Tile>();

                if (tile != null)
                {
                    if (activePreview == null)
                    {
                        activePreview = Instantiate(previewPrefab);
                    }

                    activePreview.transform.position = tile.transform.position;

                    // Color based on whether the tile is buildable
                    SpriteRenderer sr = activePreview.GetComponent<SpriteRenderer>();
                    sr.color = tile.IsOccupied() ? new Color(1f, 0f, 0f, 0.5f) : new Color(0f, 1f, 0f, 0.5f);
                }
            }
        }
        else
        {
            if (activePreview != null)
            {
                Destroy(activePreview);
            }
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

