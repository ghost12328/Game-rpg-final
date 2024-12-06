using UnityEngine;
using System.Collections.Generic;

public class ProceduralDungeon : MonoBehaviour
{
    public GameObject roomPrefab; // Prefab for a single room
    public GameObject[] enemyPrefabs; // Array of enemy prefabs to spawn
    public GameObject[] itemPrefabs;  // Array of item prefabs to spawn
    public int gridWidth = 5;     // Number of rooms horizontally
    public int gridHeight = 5;    // Number of rooms vertically
    public float roomSpacing = 10f; // Distance between rooms
    public float roomConnectionChance = 0.5f; // Chance for a room to be connected to another
    public int minEnemiesPerRoom = 1; // Minimum number of enemies per room
    public int maxEnemiesPerRoom = 3; // Maximum number of enemies per room
    public int minItemsPerRoom = 1;  // Minimum number of items per room
    public int maxItemsPerRoom = 2;  // Maximum number of items per room

    private List<GameObject> generatedRooms = new List<GameObject>();

    void Start()
    {
        GenerateDungeon();
    }

    void GenerateDungeon()
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                // Calculate the position for each room
                Vector3 roomPosition = new Vector3(x * roomSpacing, 0, y * roomSpacing);

                // Instantiate the room and store it in the list
                GameObject newRoom = Instantiate(roomPrefab, roomPosition, Quaternion.identity, transform);
                generatedRooms.Add(newRoom);

                // Randomize the room's properties
                RandomizeRoom(newRoom);

                // Spawn enemies in the room
                SpawnEnemies(newRoom);

                // Spawn items in the room
                SpawnItems(newRoom);
            }
        }

        // Optionally, connect rooms based on some logic
        ConnectRooms();
    }

    void RandomizeRoom(GameObject room)
    {
        // Example: Randomize the size of the room
        float randomSize = Random.Range(0.8f, 1.2f); // Slightly vary the size
        room.transform.localScale = new Vector3(randomSize, 1, randomSize);
    }

    void SpawnEnemies(GameObject room)
    {
        // Determine the number of enemies to spawn in this room
        int enemyCount = Random.Range(minEnemiesPerRoom, maxEnemiesPerRoom + 1);

        for (int i = 0; i < enemyCount; i++)
        {
            // Choose a random position within the room
            Vector3 randomPosition = room.transform.position + new Vector3(
                Random.Range(-roomSpacing / 2, roomSpacing / 2),
                0,
                Random.Range(-roomSpacing / 2, roomSpacing / 2)
            );

            // Choose a random enemy prefab to spawn
            if (enemyPrefabs.Length > 0)
            {
                GameObject randomEnemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
                Instantiate(randomEnemy, randomPosition, Quaternion.identity, room.transform);
            }
        }
    }

    void SpawnItems(GameObject room)
    {
        // Determine the number of items to spawn in this room
        int itemCount = Random.Range(minItemsPerRoom, maxItemsPerRoom + 1);

        for (int i = 0; i < itemCount; i++)
        {
            // Choose a random position within the room
            Vector3 randomPosition = room.transform.position + new Vector3(
                Random.Range(-roomSpacing / 2, roomSpacing / 2),
                0,
                Random.Range(-roomSpacing / 2, roomSpacing / 2)
            );

            // Choose a random item prefab to spawn
            if (itemPrefabs.Length > 0)
            {
                GameObject randomItem = itemPrefabs[Random.Range(0, itemPrefabs.Length)];
                Instantiate(randomItem, randomPosition, Quaternion.identity, room.transform);
            }
        }
    }

    void ConnectRooms()
    {
        // Example logic to connect rooms
        foreach (GameObject room in generatedRooms)
        {
            if (Random.value < roomConnectionChance)
            {
                // Implement your own logic to create connections (like corridors)
                // For simplicity, you could instantiate a corridor prefab between rooms
            }
        }
    }
}
