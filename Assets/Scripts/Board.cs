using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class Board : MonoBehaviour
{
    public Tilemap tilemap { get; private set; }
    public Piece activePiece { get; private set; }
    public Tile tile;
    public TetrominoData[] tetrominoes;
    public Vector3Int spawnPosition;

    private void Awake()
    {
        tilemap = GetComponentInChildren<Tilemap>();
        activePiece=GetComponentInChildren<Piece>();
        for (int i = 0; i < tetrominoes.Length; i++)
        {
            tetrominoes[i].Initialize();
        }
    }

    private void Start()
    {
        SpawnPiece();
    }

    private void SpawnPiece()
    {
        int random=Random.Range(0,tetrominoes.Length);
        TetrominoData data = tetrominoes[random];
        activePiece.Initialize(this,spawnPosition,data);
        Set(activePiece);
    }

    public void Set(Piece piece)
    {
        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePosition = piece.cells[i]+ piece.position;
            tilemap.SetTile(tilePosition, tile);
        }
    }
    public bool IsValidPosition(Piece piece, Vector3Int position)
    {
        for (int i = 0; i < piece.cells.Length; i++)
        {
            Vector3Int tilePosition = piece.cells[i]+ position;

            if (tilemap.HasTile(tilePosition))
            {
                return false;
            }
        }
        return true;
    }
}
