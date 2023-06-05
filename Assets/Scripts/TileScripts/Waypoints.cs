using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [SerializeField] Tower ballistaTower;   
    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }
    private void OnMouseDown()
    {
        if (isPlaceable)
        {
            bool isPlaced =  ballistaTower.CreateTower(ballistaTower,transform.position);
                    
            isPlaceable = !isPlaced;
        }
    }
}
