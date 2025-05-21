using UnityEngine;

public class Tile : MonoBehaviour
{
    private SpriteRenderer sr;
    private Color originalColor;
    private bool isOccupied = false;
    public GameObject buildingPrefab;

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

      public void PlaceBuilding()
    {
        if (isOccupied || buildingPrefab == null) return;

        Vector3 spawnPos = transform.position;
        spawnPos.z = -0.1f; // make sure it renders in front
        Instantiate(buildingPrefab, spawnPos, Quaternion.identity);
        isOccupied = true;
        sr.color = Color.white; // optional visual reset
        Debug.Log($"Building placed on {gameObject.name}");
    }
}
