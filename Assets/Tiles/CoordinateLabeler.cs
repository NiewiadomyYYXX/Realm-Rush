using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockColor = Color.gray;
    [SerializeField] Color exploredColor = Color.yellow;
    [SerializeField] Color pathColor = new Color(1f, .5f, 0f);


    TMP_Text label;
    Vector2Int coordinates = new Vector2Int();
    GridManager grid;

    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        grid = FindObjectOfType<GridManager>();
        DisplayCoordinates();
    }
    void Update()
    {
       if(!Application.isPlaying)
       {
            DisplayCoordinates();
            UpdateObjectName();
            label.enabled = true;
       }

        SetLabelColor();
        ToggleLabels();
    }

    void DisplayCoordinates()
    {
        if (grid == null) { return; }

        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / grid.UnityGridSize);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / grid.UnityGridSize);

        label.text = coordinates.x + "," + coordinates.y;
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }

    void SetLabelColor()
    {
        if(grid == null) { return; }

        Node node = grid.GetNode(coordinates);

        if(node == null ) { return; }

        if(!node.isWalkable)
        {
            label.color = blockColor;
        }
        else if(node.isPath)
        {
            label.color = pathColor;
        }
        else if (node.isExplored)
        {
            label.color = exploredColor;
        }
        else
        {
            label.color = defaultColor;
        }

    }

    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }

}
