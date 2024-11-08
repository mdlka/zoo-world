using UnityEngine;

namespace ZooWorld
{
    public class Billboard : MonoBehaviour
    {
        private Transform _camera;

        private void Awake()
        {
            _camera = Camera.main.transform;
        }

        private void Update()
        {
            transform.forward = _camera.forward;
        }
    }
}
