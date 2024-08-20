using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Node currentSearchNode;
    Vector2Int[] directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };
    GridManager gridMgmt;
    Dictionary<Vector2Int, Node> grid;

    void Awake()
    {
        gridMgmt = FindObjectOfType<GridManager>();
        grid = gridMgmt.Grid;
        if (gridMgmt != null)
        {
            grid = gridMgmt.Grid;
        }
    }

    void Start()
    {
        ExploreNeighbors();
    }

    void ExploreNeighbors()
    {
        List<Node> neighbors = new List<Node>();

        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighborCoords = currentSearchNode.coordinates + direction;

            if (grid.ContainsKey(neighborCoords))
            {
                neighbors.Add(grid[neighborCoords]);

                //TODO: Remove after testing
                grid[neighborCoords].isExplored = true;
                grid[currentSearchNode.coordinates].isPath = true;

            }

        }

    }
}
