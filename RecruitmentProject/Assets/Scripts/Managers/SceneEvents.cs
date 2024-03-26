using System;
using UnityEngine;

[CreateAssetMenu(menuName = "SceneEvents")]
public class SceneEvents : ScriptableObject
{
    public static Action<SceneObjectSo> OnSceneObjectClicked;
}
