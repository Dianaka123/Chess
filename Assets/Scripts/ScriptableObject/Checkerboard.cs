using System;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "Checkerboard", menuName = "Chess/Checkerboard", order = 0)]
    public class Checkerboard : ScriptableObject
    {
        [SerializeField] private GameObject board;

        [SerializeField] private int width = 8;
        [SerializeField] private int height = 8;
        
        [SerializeField] private Vector3 gridHorizontalStep = new Vector3(1, 0, 0);
        [SerializeField] private Vector3 gridVerticalStep = new Vector3(0, 0, 1);
        [SerializeField] private Vector3 gridOffset = Vector3.zero;
        
        public GameObject Board => board;
        public int Width => width;
        public int Height => height;
        
        public Vector3 ConvertToWorldLocation(Vector2Int position)
        {
            return gridOffset + gridHorizontalStep * position.x + gridVerticalStep * position.y;
        }

        public Vector2Int ConvertFromWorldLocation(Vector3 location)
        {
            location -= gridOffset;
            float x = Mathf.Floor(Vector3.Project(location,gridHorizontalStep).magnitude);
            float y = Mathf.Floor(Vector3.Project(location, gridVerticalStep).magnitude);
            return new Vector2Int((int)x, (int)y);
        }
    
    }
}