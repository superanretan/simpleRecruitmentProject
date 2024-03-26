using UnityEngine;

public class SceneInteractions : MonoBehaviour
{
    private Camera _camera;
    private RaycastHit _hit;
    private Ray _ray;
    private void Start()
    {
        _camera = Camera.main;
    }

   private void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
           _ray = _camera.ScreenPointToRay(Input.mousePosition);
           if (Physics.Raycast(_ray, out _hit))
           {
               if (_hit.transform.CompareTag("SceneObject"))
                   _hit.transform.GetComponent<ISceneObject>().OnObjectClicked();
           }
        }
    }
}
