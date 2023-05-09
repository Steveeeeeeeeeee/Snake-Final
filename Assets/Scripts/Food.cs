using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Food : MonoBehaviour
{
    public GameObject player;
    public GameObject segment;
    private Vector2 newPosition;

    [SerializeField]
    public Tilemap floorTilemap;
    [SerializeField]
    public Tilemap wallsTilemap;
    private List<Vector3Int> floorTilePositions;

    private List<GameObject> segments;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        segment = GameObject.FindGameObjectWithTag("Obstacle");

        floorTilePositions = GetFloorTilePositions();
        RandomPosition();
    }

    private List<Vector3Int> GetFloorTilePositions()
    {
        List<Vector3Int> positions = new List<Vector3Int>();

        BoundsInt bounds = floorTilemap.cellBounds;
        TileBase[] tiles = floorTilemap.GetTilesBlock(bounds);

        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                TileBase tile = tiles[x + y * bounds.size.x];
                if (tile != null)
                {
                    Vector3Int localPlace = new Vector3Int(x, y, 0);
                    Vector3Int tilePos = localPlace + new Vector3Int(bounds.xMin, bounds.yMin, 0);

                    if (!wallsTilemap.HasTile(tilePos))
                    {
                        positions.Add(tilePos);
                    }
                }
            }
        }

        return positions;
    }

    public void RandomPosition()
{
    bool positionOccupied = true;
    Vector3 worldPos;

    segments = player.GetComponent<SnakeGrowth>().segments;

    do
    {
        int randomIndex = Random.Range(0, floorTilePositions.Count);
        Vector3Int randomTilePos = floorTilePositions[randomIndex];
        worldPos = floorTilemap.CellToWorld(randomTilePos) + new Vector3(0.5f, 0.5f, 0); // Centering the food on the tile

        positionOccupied = false;

        // Check if the position collides with any segment GameObjects
        foreach (GameObject segment in segments)
        {
            if ((Vector2)segment.transform.position == (Vector2)worldPos)
            {
                positionOccupied = true;
                break;
            }
        }

        // Check if the position collides with any obstacle GameObjects
        if (!positionOccupied)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(worldPos, 0.1f);
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Obstacle"))
                {
                    positionOccupied = true;
                    break;
                }
            }
        }

    } while (positionOccupied);

    transform.position = worldPos;
}


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player || other.gameObject == segment)
        {
            RandomPosition();
        }
    }
}
