using UnityEngine;

namespace Ships
{
    public class UnityInputAdapter : Input
    {
        public Vector2 GetDirection()
        {
            var _horizontalInput = UnityEngine.Input.GetAxis("Horizontal");
            var _verticalInput = UnityEngine.Input.GetAxis("Vertical");

            return new Vector2(_horizontalInput, _verticalInput);
        }
    }
}