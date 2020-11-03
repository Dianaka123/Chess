using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "Chess", menuName = "Chess/ Chess", order = 0)]
    public class ChessByColor : ScriptableObject
    {
        [SerializeField] private Piece kingPiece;
        [SerializeField] private Piece queenPiece;
        [SerializeField] private Piece knightPiece;
        [SerializeField] private Piece bishopPiece;
        [SerializeField] private Piece castlePiece;
        [SerializeField] private Piece pawnPiece;

        public Piece[,] GetPieces()
        {
            var result = new Piece[8, 2];
            result[0, 0] = castlePiece;
            result[1, 0] = knightPiece;
            result[2, 0] = bishopPiece;
            result[3, 0] = kingPiece;
            result[4, 0] = queenPiece;
            result[5, 0] = bishopPiece;
            result[6, 0] = knightPiece;
            result[7, 0] = castlePiece;
            for (int i = 0; i < 8; i++)
            {
                result[i, 1] = pawnPiece;
            }
            return result;
        }
        
    }
}