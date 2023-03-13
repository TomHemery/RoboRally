using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Board : MonoBehaviour
{
    public Dictionary<Vector3, Robot> Robots { get; protected set; } = new Dictionary<Vector3, Robot>();
    public List<RobotSpawnPoint> SpawnPoints { get; protected set; }

    private void Start()
    {
        SpawnPoints = GetComponentsInChildren<RobotSpawnPoint>().ToList();

        // Probably just debug
        foreach (var spawnPoint in SpawnPoints) {
            spawnPoint.SpawnRobot();
        }
    }   

    public Vector3 BoardPositionToWorldPosition(Vector3Int boardPosition)
    {
        return transform.position + boardPosition + new Vector3(0.5f, 0.5f, 0.5f);
    }
}
