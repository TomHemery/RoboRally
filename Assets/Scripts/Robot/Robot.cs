using System;
using UnityEngine;
using UnityEngine.AI;

public class Robot : MonoBehaviour
{
    protected Vector3Int boardPosition;
    protected Board board;

    protected bool moving = false;
    protected Vector3Int newBoardPosition;
    protected Vector3 newPosition;
    protected Vector3Int movementDirection;
    protected int moveSteps = 0;

    [SerializeField]
    protected float moveSpeed = 1.0f;

    private void Start()
    {
        board = GameObject.FindGameObjectWithTag("Board").GetComponent<Board>();
    }
    
    private void Update()
    {
        // DEBUG
        if (!moving && Input.GetKeyDown(KeyCode.W)) {
            TriggerMove(2);
        } else if (!moving && Input.GetKeyDown(KeyCode.S)) {
            TriggerMove(-2);
        } else if (!moving && Input.GetKeyDown(KeyCode.A)) {
            Turn(-90);
        } else if (!moving && Input.GetKeyDown(KeyCode.D)) {
            Turn(90);
        }
    }

    private void FixedUpdate()
    {
        if (moving) {
            float step = moveSpeed * Time.fixedDeltaTime;
            transform.position = Vector3.MoveTowards(transform.position, newPosition, step);
            if (transform.position == newPosition) {
                boardPosition = newBoardPosition;
                transform.position = board.BoardPositionToWorldPosition(newBoardPosition);
                moveSteps--;
                if (moveSteps <= 0) {
                    moving = false;
                } else {
                    TriggerSingleMove(movementDirection);
                }
            }
        }
    }

    public void SetBoardPosition(Vector3Int boardPosition)
    {
        this.boardPosition = boardPosition;
    }

    public void Turn(int degrees)
    {
        transform.Rotate(0, degrees, 0);
    }

    public void TriggerMove(int distance)
    {
        if (distance == 0) {
            throw new Exception("Cannot move a distance of 0!");
        }

        moveSteps = Math.Abs(distance);
        if (distance > 0) {
            TriggerSingleMove(1);
        } else if (distance < 0) {
            TriggerSingleMove(-1);
        }
    }

    protected void TriggerSingleMove(int dir)
    {
        // Negative numbers are a pain
        TriggerSingleMove(new Vector3Int((int)Math.Truncate(transform.forward.x), 0, (int)Math.Truncate(transform.forward.z)) * dir);
    }

    protected void TriggerSingleMove(Vector3Int movementDirection)
    {
        this.movementDirection = movementDirection;
        newBoardPosition = boardPosition + movementDirection;
        newPosition = board.BoardPositionToWorldPosition(newBoardPosition);
        moving = true;
    }
}