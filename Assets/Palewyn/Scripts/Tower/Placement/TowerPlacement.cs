using System.Collections;
using System.Collections.Generic;
using TowerDefense.Towers.Placement;
using Core.Utilities;
using UnityEngine;


public class TowerPlacement : MonoBehaviour
{
    public LayerMask hitLayers;

    private void OnDrawGizmos()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(camRay.origin, camRay.origin + camRay.direction * 1000f);
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(camRay, out hit, 1000f, hitLayers))
            {
                IPlacementArea placement = hit.collider.GetComponent<IPlacementArea>();
                if (placement != null)
                {
                    transform.position = placement.Snap(hit.point, new IntVector2(1, 1));
                }
            }
        }
    }
}
