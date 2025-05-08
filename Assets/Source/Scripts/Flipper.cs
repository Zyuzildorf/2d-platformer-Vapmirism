using UnityEngine;

public class Flipper : MonoBehaviour
{
    private float _rotateAngle = 180;
    private bool _isRotatedToRight = false;
    private bool _isRotatedToLeft = false;
    
    public void Flip(float direction)
    {
        if (Mathf.Sign(direction) > 0)
        {
            RotateIfNeeded(_rotateAngle, ref _isRotatedToRight, ref _isRotatedToLeft);
        }
        else if (Mathf.Sign(direction) < 0)
        {
            RotateIfNeeded(-_rotateAngle, ref _isRotatedToLeft, ref _isRotatedToRight);
        }
    }
    
    private void RotateIfNeeded(float angle, ref bool isRotated, ref bool isOppositeRotated)
    {
        if (isRotated == false)
        {
            transform.RotateAround(transform.position, Vector3.up, angle);
            isRotated = true;
            isOppositeRotated = false;
        }
    }
}