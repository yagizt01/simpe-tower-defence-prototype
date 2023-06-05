using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    Waypoints waypoint;

    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.grey;
    
    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        waypoint = GetComponentInParent<Waypoints>();
        DisplayCoordinates();

        
    }

    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
            label.enabled = true;

        }

        SetLabelColor();
        ToggleLabel();

    }

    void SetLabelColor()
    {
        if (waypoint.IsPlaceable)
        {
            label.color = defaultColor;         
        }
        else
        {
            label.color = blockedColor;
        }
    }

    void ToggleLabel()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.enabled;
        }
    }
    void DisplayCoordinates()
    {
        coordinates.x =Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y =Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        label.text = coordinates.x + "," + coordinates.y;
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
        
    }
}
