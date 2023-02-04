using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[InitializeOnLoad()]
public class editor_waypoint
{
    [DrawGizmo(GizmoType.NonSelected | GizmoType.Selected| GizmoType.Pickable)]
    public static void OnDrawScenGizmos(waypoints waypoint, GizmoType gizmoType){
        if((gizmoType & GizmoType.Selected)!= 0){
            Gizmos.color = Color.blue;
        }
        else{
            Gizmos.color = Color.blue*.5f;
        }
        Gizmos.DrawSphere(waypoint.transform.position,.5f);

        Gizmos.color = Color.white;

        Gizmos .DrawLine(waypoint.transform.position+
        (waypoint.transform.right* waypoint.waypointwidth/2f),
         waypoint.transform.position-(waypoint.transform.right*waypoint.waypointwidth/2f));

         if(waypoint.previousway!= null){
            Gizmos.color = Color.red;
            Vector3 offset= waypoint.transform.right * waypoint.waypointwidth/2f;
            Vector3 offsetto= waypoint.previousway.transform.right* waypoint.previousway.waypointwidth/2f;

            Gizmos.DrawLine(waypoint.transform.position + offset, waypoint.previousway.transform.position+offsetto);
        }
        if(waypoint.nextway!=null){
                Gizmos.color = Color.green;
            Vector3 offset= waypoint.transform.right * -waypoint.waypointwidth/2f;
            Vector3 offsetto= waypoint.previousway.transform.right* -waypoint.previousway.waypointwidth/2f;

            Gizmos.DrawLine(waypoint.transform.position + offset, waypoint.previousway.transform.position+offsetto);

            }

    }
}
