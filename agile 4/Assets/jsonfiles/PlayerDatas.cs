using UnityEngine;

[System.Serializable]
public class PlayerDatas
{
    public SerializableVector3 position;
    public SerializableVector3 rotation; // Use SerializableVector3 for rotation if necessary
    public string currentMap;

    public PlayerDatas(Vector3 position, Quaternion rotation, string map)
    {
        this.position = new SerializableVector3(position);
        this.rotation = new SerializableVector3(rotation.eulerAngles); // Convert Quaternion to euler angles
        this.currentMap = map;
    }

    public Vector3 GetPosition()
    {
        return position.ToVector3();
    }

    public Quaternion GetRotation()
    {
        return Quaternion.Euler(rotation.ToVector3()); // Convert euler angles back to Quaternion
    }
}
