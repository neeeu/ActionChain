using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using NEEEU.ActionChain;

[CustomEditor(typeof(ActionChain))]
public class ActionChainEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ActionChain myTarget = (ActionChain)target;

        if (GUILayout.Button("Trigger"))
        {
            myTarget.trigger?.Invoke();
        }        
    }
}
