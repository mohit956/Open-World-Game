using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WaypointManagementWindow : EditorWindow
{
    [MenuItem("Waypoint/Waypoints Editor Tools")]
    public static void ShowWindow()
    {
        GetWindow<WaypointManagementWindow>("waypoint_editor_window");
    }
    public Transform waypointOrigen;

    private void OnGUI(){
        SerializedObject obj = new SerializedObject(this);

        EditorGUILayout.PropertyField(obj.FindProperty("waypointOrigen"));

        if(waypointOrigen==null){
            EditorGUILayout.HelpBox("please assign origen",MessageType.Warning);
        }
        else{
            EditorGUILayout.BeginVertical("box");
            CreateButtons();
            EditorGUILayout.EndVertical();
        }
        obj.ApplyModifiedProperties();
    }
    void CreateButtons(){
        if(GUILayout.Button("create waypoint")){
            createwaypoint();
        }
    }
    void createwaypoint(){
        GameObject waypointobject = new GameObject("waypoint"+ waypointOrigen.childCount,typeof(waypoints));
        waypointobject.transform.SetParent(waypointOrigen,false);

        waypoints waypoint =waypointobject.GetComponent<waypoints>();
        if(waypointOrigen.childCount>1){
            waypoint.previousway=waypointOrigen.GetChild(waypointOrigen.childCount-2).GetComponent<waypoints>();
            waypoint.previousway.nextway = waypoint;
            waypoint.transform.position = waypoint.previousway.transform.position;
            waypoint.transform.forward= waypoint.previousway.transform.forward;

        }
        Selection.activeGameObject = waypoint.gameObject;
    }
}
