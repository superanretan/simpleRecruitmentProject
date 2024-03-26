using System;
using UnityEngine;

public class SceneObject : MonoBehaviour , ISceneObject
{
    [SerializeField] private SceneObjectSo sceneObjectSo;
    public SceneObjectSo SceneObjectSo => sceneObjectSo;

    private void Start()
    {
        this.transform.tag = "SceneObject";
    }

    public void OnObjectClicked()
    {
        SceneEvents.OnSceneObjectClicked?.Invoke(sceneObjectSo);
    }
}
