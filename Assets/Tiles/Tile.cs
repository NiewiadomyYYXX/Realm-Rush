using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }

    GridManager grid;
    Vector2Int coordinates = new Vector2Int();

    void Awake()
    {
        grid = FindAnyObjectByType<GridManager>();
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
        if (isPlaceable)
        {
            bool isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
            isPlaceable = !isPlaced;
        }
    }
}
