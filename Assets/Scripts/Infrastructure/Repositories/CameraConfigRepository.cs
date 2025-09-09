using UnityEngine;

namespace Infrastructure.Repositories
{
    [CreateAssetMenu(fileName = "CameraConfigRepository",
        menuName = "Config/Camera Config Repository")]
    public class CameraConfigRepository : ScriptableObject
    {
        [Header("Camera Move Speed")]
        [SerializeField, Min(0.1f)]
        private float moveSpeed = 10f;
        public float MoveSpeed => moveSpeed;

        [Header("Camera Drag Speed")]
        [SerializeField, Min(0.1f)]
        private float dragSpeed = 0.5f;
        public float DragSpeed => dragSpeed;

        [Header("Camera Zoom Speed")]
        [SerializeField, Min(0.1f)]
        private float zoomSpeed = 10f;
        public float ZoomSpeed => zoomSpeed;

        [Header("Zoom Limits")]
        [SerializeField, Min(0.1f)]
        private float minZoom = 5f;
        public float MinZoom => minZoom;

        [SerializeField, Min(0.1f)]
        private float maxZoom = 40f;
        public float MaxZoom => maxZoom;
    }
}
