using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    private InputActionAsset _actionFile;
    private InputAction _cameraMovement;
    private Transform _followTarget;
    [SerializeField] private float m_rotationSpeed;
    [Tooltip("Please make sure the bottom clamp value is under the top clamp value")]
    [SerializeField] private float m_bottomClamp;
    [Tooltip("Please make sure the bottom clamp value is under the top clamp value")]
    [SerializeField] private float m_topClamp;

    //en haut
    private float cinemachineTargetPitch;
    //gauche droite
    private float cinemachineTargetYaw;

    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _actionFile = InputSystem.actions;
        _followTarget = transform;
        _cameraMovement = _actionFile.FindAction("Look");
        if (m_bottomClamp > m_topClamp)
        {
            Debug.LogError("Your bottom clamp and top clamp values are inverted. Please make sure the bottom clamp value is smaller than your top clamp value.");
        }
    }

    void LateUpdate()
    {
        CameraLogic();
    }

    private void CameraLogic()
    {
        Vector2 camAmt = _cameraMovement.ReadValue<Vector2>();

        cinemachineTargetPitch = UpdateRotation(cinemachineTargetPitch, camAmt.y, m_bottomClamp, m_topClamp, true);
        cinemachineTargetYaw = UpdateRotation(cinemachineTargetYaw, camAmt.x, float.MinValue, float.MaxValue, false);

        ApplyRotation(cinemachineTargetPitch, cinemachineTargetYaw);
    }

    private void ApplyRotation(float pitch, float yaw)
    {
        _followTarget.rotation = Quaternion.Euler(pitch, yaw, 0);
    }

    private float UpdateRotation(float currentRotation, float input, float min, float max, bool isXAxis)
    {
        currentRotation += isXAxis ? -input * m_rotationSpeed * Time.deltaTime : input * m_rotationSpeed * Time.deltaTime;
        return Mathf.Clamp(currentRotation, min, max);

    }
}