using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int width = 10;
    public int height = 10;
    public GameObject tilePrefab;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
    float offsetX = -(width - 1) / 2f;
    float offsetY = -(height - 1) / 2f;

    for (int x = 0; x < width; x++)
    {
        for (int y = 0; y < height; y++)
        {
            Vector2 position = new Vector2((x + offsetX), (y + offsetY));
            GameObject tile = Instantiate(tilePrefab, position, Quaternion.identity);
            tile.name = $"Tile_{x}_{y}";
            tile.transform.parent = this.transform;
        }
    }
}
}
