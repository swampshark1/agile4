using System.Collections.Generic;
using System;

[Serializable]
public class GameData
{
    public string sceneName; // Stores the name of the current scene
    public float[] playerPosition; // Stores player's position as an array of floats
    public List<EnemyData> enemies; // List of enemies' states
    public List<DoorData> doors; // List of doors' states
    public List<KeyData> keys; // List of keys' states
    public string timeStamp; // Time of the save

    // Constructor
    public GameData()
    {
        enemies = new List<EnemyData>();
        doors = new List<DoorData>();
        keys = new List<KeyData>();
    }
}

[Serializable]
public class EnemyData
{
    public bool isDead;
    public float[] position;

    public EnemyData(bool isDead, float[] position)
    {
        this.isDead = isDead;
        this.position = position;
    }
}

[Serializable]
public class DoorData
{
    public bool isOpen;

    public DoorData(bool isOpen)
    {
        this.isOpen = isOpen;
    }
}

[Serializable]
public class KeyData
{
    public string keyID; // Unique identifier for the key
    public bool isCollected;

    public KeyData(string keyID, bool isCollected)
    {
        this.keyID = keyID;
        this.isCollected = isCollected;
    }
}
