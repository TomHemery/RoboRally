using UnityEngine;

[ExecuteInEditMode]
public class RobotSpawnPoint : MonoBehaviour
{
    [SerializeField]
    protected Vector3Int boardPosition;
    [SerializeField]
    protected GameObject robotPrefab;
    protected Board parentBoard;

    private void Awake()
    {
        FindParentBoard();
    }

    private void OnValidate()
    {
        FindParentBoard();
        if (parentBoard == null || !Application.isEditor) {
            return;
        }

        transform.position = parentBoard.BoardPositionToWorldPosition(boardPosition);
    }

    private void FindParentBoard()
    {
        if (parentBoard == null) {
            parentBoard = GetComponentInParent<Board>();
        }
    }

    public void SpawnRobot()
    {
        if (parentBoard == null) {
            throw new System.Exception("No parent board exists for robot spawn point, cannot spawn robot");
        }

        GameObject robotGameObject = Instantiate(robotPrefab, transform.position, transform.rotation);
        Robot robot = robotGameObject.GetComponent<Robot>();
        robot.SetBoardPosition(boardPosition);
    }
}
