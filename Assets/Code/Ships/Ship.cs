using UnityEngine;

namespace Ships
{
    public class Ship : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private Joystick _joystick;
        [SerializeField] private float _viewportPointMinValue = 0.03f;
        [SerializeField] private float _viewportPointMaxValue = 0.97f;
        private Transform _myTransform;
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
            _myTransform = transform;
        }

        private void Update()
        {
            var direction = GetDirection();
            Move(direction);
        }

        private void Move(Vector2 direction)
        {
            _myTransform.Translate(direction * (_speed * Time.deltaTime));
            ClampFinalPosition();
        }

        private void ClampFinalPosition()
        {
            var viewportPoint = _camera.WorldToViewportPoint(_myTransform.position);
            viewportPoint.x = Mathf.Clamp(viewportPoint.x, _viewportPointMinValue, _viewportPointMaxValue);
            viewportPoint.y = Mathf.Clamp(viewportPoint.y, _viewportPointMinValue, _viewportPointMaxValue);
            _myTransform.position = _camera.ViewportToWorldPoint(viewportPoint);
        }

        private Vector2 GetDirection()
        {
            return new Vector2(_joystick.Horizontal, _joystick.Vertical);
            
            var horizontalDir = Input.GetAxis("Horizontal");
            var verticalDir = Input.GetAxis("Vertical");
            return new Vector2(horizontalDir, verticalDir);
        }
    }
}
