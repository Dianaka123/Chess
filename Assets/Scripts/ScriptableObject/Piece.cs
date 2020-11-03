using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

[CreateAssetMenu(fileName = "Piece",menuName = "Chess/Piece", order = 0)]
public class Piece : ScriptableObject
{
    [SerializeField] private NamePiece pieceName;
    [SerializeField] private GameObject prefabLight;
    [SerializeField] private GameObject prefabDark;

    public NamePiece PieceName => pieceName;
    public GameObject PrefabLight => prefabLight;

    public GameObject PrefabDark => prefabDark;
}
