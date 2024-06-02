using System.Collections;
using System.Collections.Generic;
using System.IO;
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
    [SerializeField] private GameObject spikesPrefab;
    [SerializeField] private GameObject dartsPrefab;
    [SerializeField] private GameObject finishPrefab;
    [SerializeField] private GameObject bulletAmmoBoxPrefab;
    [SerializeField] private GameObject bombAmmoBoxPrefab;
    [SerializeField] private GameObject simpleTreasurePrefab;
    [SerializeField] private GameObject expensiveTreasurePrefab;

    private void Start()
    {
        LoadLevel();
    }

    private void LoadLevel()
    {
        string levelFolderPath = Path.Combine(Application.dataPath, "Level Files");

        // Find the specific file
        //string[] files = Directory.GetFiles(levelFolderPath, $"{levelFileName}.json", SearchOption.AllDirectories);
        string[] files = Directory.GetFiles(levelFolderPath, "levelA.json", SearchOption.AllDirectories);

        if (files.Length > 0)
        {
            string filePath = files[0];
            string jsonContent = File.ReadAllText(filePath);
            LevelData levelData = JsonUtility.FromJson<LevelData>(jsonContent);
            GenerateLevel(levelData);
        }
        else
        {
            //Debug.LogError($"Level file {}.json not found in {levelFolderPath}");
            Debug.LogError($"Level file levelA.json not found in {levelFolderPath}");
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
                        //Ground Block
                        SetGroundTileBlock(basePosition);
                        break;
                    case '0':
                        //Nothing
                        break;
                    case 'P':
                        //PLayer
                        GameObject player = GameObject.FindGameObjectWithTag("Player");
                        Vector3 playerPosition = new Vector3(basePosition.x + 1, basePosition.y, basePosition.z);
                        player.transform.position = playerPosition;
                        break;
                    case 'E':
                        //Enemy
                        Instantiate(enemyPrefab, basePosition, Quaternion.identity);
                        break;
                    case 'S':
                        //Spikes
                        Vector3 spikePosition = new Vector3(basePosition.x + 0.55f, basePosition.y, basePosition.z);
                        Instantiate(spikesPrefab, spikePosition, Quaternion.identity);
                        break;
                    case 'D':
                        //Darts

                        if (x == 0 || row[x - 1] == 1)
                        {
                            Vector3 dartPosition = new Vector3(basePosition.x + 0.2f, basePosition.y, basePosition.z);
                            Instantiate(dartsPrefab, dartPosition, Quaternion.identity);

                        }
                        else if (x == row.Length - 1 || row[x + 1] == 1)
                        {
                            Vector3 dartPosition = new Vector3(basePosition.x + 1.7f, basePosition.y, basePosition.z);
                            GameObject dart = Instantiate(dartsPrefab, dartPosition, Quaternion.identity);
                            dart.transform.Rotate(0, 180, 0);
                        }
                        break;
                    case 'F':
                        //Finish

                        if (x == row.Length - 1 || row[x + 1] == 1)
                        {

                            Vector3 finishPosition = new Vector3(basePosition.x + 1.5f, basePosition.y, basePosition.z);
                            Instantiate(finishPrefab, finishPosition, Quaternion.identity);

                        }
                        else if (x == 0 || row[x - 1] == 1 || (row[x - 1] != 1 && row[x + 1] != 1))
                        {
                            Vector3 finishPosition = new Vector3(basePosition.x + 0.5f, basePosition.y, basePosition.z);
                            Instantiate(finishPrefab, finishPosition, Quaternion.identity);
                        }

                        break;
                    case 'A':
                        //Bullet Ammo Box
                        Vector3 bulletAmmoBoxPosition = new Vector3(basePosition.x, basePosition.y - 0.35f, basePosition.z);
                        Instantiate(bulletAmmoBoxPrefab, bulletAmmoBoxPosition, Quaternion.identity);
                        break;
                    case 'B':
                        //Bomb Ammo Box
                        Vector3 bombAmmoBoxPosition = new Vector3(basePosition.x, basePosition.y - 0.35f, basePosition.z);
                        Instantiate(bombAmmoBoxPrefab, bombAmmoBoxPosition, Quaternion.identity);
                        break;
                    case 'T':
                        //Simple Treasure
                        Vector3 simpleTreasurePosition = new Vector3(basePosition.x, basePosition.y - 0.35f, basePosition.z);
                        Instantiate(simpleTreasurePrefab, simpleTreasurePosition, Quaternion.identity);
                        break;
                    case 'U':
                        //Expensive Treasure
                        Vector3 expensiveTreasurePosition = new Vector3(basePosition.x, basePosition.y - 0.35f, basePosition.z);
                        Instantiate(expensiveTreasurePrefab, expensiveTreasurePosition, Quaternion.identity);
                        break;
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
        int borderThickness = 8; // Number of rows/columns to add as a border
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
