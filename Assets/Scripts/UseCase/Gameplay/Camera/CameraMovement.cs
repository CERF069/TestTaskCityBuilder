using System;
using ContractsInterfaces.UseCasesGameplay;
using UnityEngine;
using VContainer.Unity;
using Domain.Gameplay.MessagesDto.Camera;
using MessagePipe;

namespace UseCase.Gameplay.Camera
{
    public class CameraMovement : ICameraMovementUseCase, ITickable, IInitializable, IDisposable
    {
        private readonly UnityEngine.Camera _camera;

        private readonly float _moveSpeed;
        private readonly float _dragSpeed;
        private readonly float _zoomSpeed;
        private readonly float _minZoom;
        private readonly float _maxZoom;

        private Vector2 _moveInput;
        private Vector2? _dragDelta;
        private bool _dragging;
        private float _zoomInput;

        private readonly GameplayControls _controls;
        private readonly IPublisher<CameraDragStartedMessage> _dragStartedPublisher;
        private readonly IPublisher<CameraDragEndedMessage> _dragEndedPublisher;

        public CameraMovement(
            UnityEngine.Camera camera,
            IPublisher<CameraDragStartedMessage> dragStartedPublisher,
            IPublisher<CameraDragEndedMessage> dragEndedPublisher,
            float moveSpeed,
            float dragSpeed,
            float zoomSpeed,
            float minZoom,
            float maxZoom)
        {
            _camera = camera;
            _moveSpeed = moveSpeed;
            _dragSpeed = dragSpeed;
            _zoomSpeed = zoomSpeed;
            _minZoom = minZoom;
            _maxZoom = maxZoom;

            _controls = new GameplayControls();
            _dragStartedPublisher = dragStartedPublisher;
            _dragEndedPublisher = dragEndedPublisher;
        }

        public void Initialize()
        {
            _controls.Camera.Move.performed += ctx => _moveInput = ctx.ReadValue<Vector2>();
            _controls.Camera.Move.canceled += ctx => _moveInput = Vector2.zero;

            _controls.Camera.DragButton.started += ctx =>
            {
                _dragging = true;
                _dragStartedPublisher.Publish(new CameraDragStartedMessage());
            };

            _controls.Camera.DragButton.canceled += ctx =>
            {
                _dragging = false;
                _dragDelta = null;
                _dragEndedPublisher.Publish(new CameraDragEndedMessage());
            };

            _controls.Camera.Drag.performed += ctx =>
            {
                if (_dragging)
                    _dragDelta = ctx.ReadValue<Vector2>();
            };

            _controls.Camera.Zoom.performed += ctx =>
            {
                _zoomInput = ctx.ReadValue<float>();
            };
        }

        public void Enable() => _controls.Camera.Enable();
        public void Disable() => _controls.Camera.Disable();

        public void Tick()
        {
            // WASD / стрелки
            if (_moveInput != Vector2.zero)
            {
                Vector3 dir = new Vector3(_moveInput.x, 0f, _moveInput.y);
                _camera.transform.position += dir * _moveSpeed * Time.deltaTime;
            }

            // Drag
            if (_dragDelta.HasValue)
            {
                Vector3 delta = _dragDelta.Value;
                _camera.transform.position -= new Vector3(delta.x, 0f, delta.y) * _dragSpeed * Time.deltaTime;
                _dragDelta = null;
            }

            // Zoom
            if (Mathf.Abs(_zoomInput) > 0.01f)
            {
                if (_camera.orthographic == false)
                {
                    // Изменяем поле зрения
                    _camera.fieldOfView -= _zoomInput * _zoomSpeed;
                    _camera.fieldOfView = Mathf.Clamp(_camera.fieldOfView, _minZoom, _maxZoom);
                }
                else
                {
                    // Орто-камера
                    _camera.orthographicSize -= _zoomInput * _zoomSpeed;
                    _camera.orthographicSize = Mathf.Clamp(_camera.orthographicSize, _minZoom, _maxZoom);
                }

                _zoomInput = 0f;
            }
        }

        public void Dispose() => _controls?.Dispose();
    }
}
