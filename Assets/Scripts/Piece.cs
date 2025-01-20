using System;
using UnityEngine;

public class Piece : MonoBehaviour
{
    public Board board { get;private set; }
    public TetrominoData data { get;private set; }
    public Vector3Int [] cells { get;private set; }
    public Vector3Int position { get;private set; }
    public void Initialize(Board board ,Vector3Int position,TetrominoData data)
    {
        this.board = board;
        this.position = position;
        this.data = data;

        if (cells == null)
        {
            cells = new Vector3Int[data.cells.Length];
        }

        for (int i = 0; i < data.cells.Length; i++)
        {
            cells[i]=(Vector3Int)data.cells[i];
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Move(Vector2Int.left);
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            Move(Vector2Int.right);
        }
    }

    private void Move(Vector2Int translation)
    {
       Vector3Int newPosition = position;
       newPosition.x += translation.x;
       newPosition.y += translation.y;
    }
}