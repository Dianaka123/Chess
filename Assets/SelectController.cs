using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class SelectController : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private Checkerboard checkerboard;
    [SerializeField] private ChessController chessController;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit))
            {
                var gridLocation = checkerboard.ConvertFromWorldLocation(hit.point);
                var pieceInfo = chessController.GetPieceInfo(gridLocation);
                if (pieceInfo == null)
                {
                    return;
                }
                Debug.Log(pieceInfo.Piece.PieceName);
            }
        }
    }
}
