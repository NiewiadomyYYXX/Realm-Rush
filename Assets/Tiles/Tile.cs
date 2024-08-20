using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }

    GridManager grid;
    Pathfinder pathfinder;
    Vector2Int coordinates = new Vector2Int();

    void Awake()
    {
        grid = FindAnyObjectByType<GridManager>();
        pathfinder = FindAnyObjectByType<Pathfinder>();
    }

    void Start()
    {
        if(grid != null)
        {
            coordinates = grid.GetCoordinatesFromPosition(transform.position);

            if(!isPlaceable)
            {
                grid.BlockNode(coordinates);
            }
        }    
    }

    void OnMouseDown()
    {
        if (grid.GetNode(coordinates).isWalkable && !pathfinder.WillBlockPath(coordinates))
        {
            bool isSuccessful = towerPrefab.CreateTower(towerPrefab, transform.position);
            if (isSuccessful)
            {
                grid.BlockNode(coordinates);
                pathfinder.NotifyReceivers();
            }
        }
    }
}
