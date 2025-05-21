using UnityEngine;

public class GridManager : MonoBehavior
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
        for (int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                GameObject tile = Instantiate(tilePrefab, new Vector3(x,y), Quaternion.Identity);
                tile.name =$"Tile {x}, {y}";
                tile.transform.parent = this.transform;
            }
        }
    }
}
