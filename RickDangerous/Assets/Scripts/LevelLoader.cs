using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private TextAsset jsonFile;
    [SerializeField] private Tilemap backgroundTileMap;
    [SerializeField] private Tilemap groundTilemap;
    [SerializeField] private Tile groundTile;
    [SerializeField] private Tile backgroundTile;
    [SerializeField] private Tile wallTile;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject playerPrefab;

    private void Start()
    {
        LoadLevel();
    }

    private void LoadLevel()
    {
        if (jsonFile != null)
        {
            LevelData levelData = JsonUtility.FromJson<LevelData>(jsonFile.text);
            GenerateLevel(levelData);
        }
    }

    private void GenerateLevel(LevelData levelData)
    {
        // Calculate level bounds
        int width = levelData.level[0].Length * 2;
        int height = levelData.level.Count * 2;

        // Set background tiles
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Vector3Int position = new Vector3Int(x, -y, 0);
                backgroundTileMap.SetTile(position, backgroundTile);
            }
        }

        

        for (int y = 0; y < levelData.level.Count; y++)
        {
            string row = levelData.level[y];
            for (int x = 0; x < row.Length; x++)
            {
                char cell = row[x];
                Vector3Int basePosition = new Vector3Int(x * 2, -y * 2, 0); // Adjust y-axis for 2D

                switch (cell)
                {
                    case '1':
                        SetGroundTileBlock(basePosition);
                        break;
                    case '0':
                        break;
                    case 'P':
                        //fin the object in the scene with the tag "Player" and set the position to the basePosition
                        GameObject player = GameObject.FindGameObjectWithTag("Player");
                        player.transform.position = basePosition;

                        break;
                    case 'E':
                        Instantiate(enemyPrefab, basePosition, Quaternion.identity);
                        break;
                        // Add more cases as needed
                }
            }
        }
        SetBorderGroundTiles(levelData);
    }

    private void SetGroundTileBlock(Vector3Int basePosition)
    {
        groundTilemap.SetTile(basePosition, groundTile);
        groundTilemap.SetTile(new Vector3Int(basePosition.x + 1, basePosition.y, basePosition.z), groundTile);
        groundTilemap.SetTile(new Vector3Int(basePosition.x, basePosition.y - 1, basePosition.z), groundTile);
        groundTilemap.SetTile(new Vector3Int(basePosition.x + 1, basePosition.y - 1, basePosition.z), groundTile);
    }

    private void SetBorderGroundTiles(LevelData levelData)
    {
        int borderThickness = 5; // Number of rows/columns to add as a border
        int width = levelData.level[0].Length * 2;
        int height = levelData.level.Count * 2;

        // Place multiple rows above and below the main generated area
        for (int y = 1; y <= borderThickness; y++)
        {
            for (int x = -borderThickness; x < width + borderThickness; x++)
            {
                // Above the level
                groundTilemap.SetTile(new Vector3Int(x, y, 0), groundTile);
                // Below the level
                groundTilemap.SetTile(new Vector3Int(x, -height - y + 1, 0), groundTile);
            }
        }

        // Place multiple columns to the left and right of the main generated area
        for (int x = 1; x <= borderThickness; x++)
        {
            for (int y = -height - 2; y <= 0; y++)
            {
                // To the left of the level
                groundTilemap.SetTile(new Vector3Int(-x, y, 0), groundTile);
                // To the right of the level
                groundTilemap.SetTile(new Vector3Int(width + x - 1, y, 0), groundTile);
            }
        }
    }
}
