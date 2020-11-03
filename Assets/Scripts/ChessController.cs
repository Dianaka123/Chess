using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;


public class ChessController : MonoBehaviour
{
    [SerializeField] private ChessByColor chessByColor;
    [SerializeField] private Checkerboard chessboard;
    
    [SerializeField] private Transform Light;
    [SerializeField] private Transform Dark;

    private PieceInfo[,] pieceInfos;

    private void Start()
    {
        pieceInfos = new PieceInfo[chessboard.Width, chessboard.Height];
        
        Instantiate(chessboard.Board, Vector3.zero, Quaternion.identity);
        InstantiatePieces(0, 1, true, Light);
        InstantiatePieces(chessboard.Height - 1, -1, false, Dark);
    }

    private void InstantiatePieces(int offsetY, int directionY, bool switchPrefab, Transform parent)
    {
        Piece[,] pieces = chessByColor.GetPieces();
        for (int x = 0;  x <= pieces.GetUpperBound(0); x++)
        {
            for (int y = 0; y <= pieces.GetUpperBound(1); y++)
            {
                int realY = offsetY + y * directionY;
                var position = chessboard.ConvertToWorldLocation(new Vector2Int(x, realY));
                var instantiatedObject = Instantiate(switchPrefab ? pieces[x, y].PrefabLight : pieces[x, y].PrefabDark, position, 
                    Quaternion.identity, parent);
                pieceInfos[x, realY] = new PieceInfo(switchPrefab, pieces[x, y], instantiatedObject);
            }
        }
    }

    public PieceInfo GetPieceInfo(Vector2Int position)
    {
        return pieceInfos[position.x, position.y];
    }

    public void MovePiece(PieceInfo info, Vector2Int from, Vector2Int to)
    {
        var toPiece = pieceInfos[to.x, to.y];
        pieceInfos[from.x, from.y] = null;
        if (toPiece != null && toPiece.IsDark != info.IsDark) 
        {
            Destroy(toPiece.GameObject);
        }
        pieceInfos[to.x, to.y] = info;
        info.GameObject.transform.position = chessboard.ConvertToWorldLocation(to);
    }
    
}
