using UnityEngine;

namespace DefaultNamespace
{
    public class PieceInfo
    {
        public readonly bool IsDark;
        public readonly GameObject GameObject;
        public readonly Piece Piece;

        public PieceInfo(bool isDark, Piece piece, GameObject gameObject)
        {
            IsDark = isDark;
            GameObject = gameObject;
            Piece = piece;
        }
    }

}