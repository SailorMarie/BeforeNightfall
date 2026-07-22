using System;
using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputControler : MonoBehaviour
{
    private InputActionAsset m_inputAction;

    [SerializeField]private float m_speed;
    [SerializeField]private int m_jumpForce;
    [SerializeField]private int m_maxDistance = 1000; //max distance du rayCast
    [SerializeField] private Material m_objectHightlightMaterial;
    [SerializeField] private CameraFollow m_cameraFollow;

    private const int DIRECTION = 10000;
   
    private Rigidbody m_body;
    private Vector2 m_movementInput;
    private Vector2 m_jumpAction;
    private bool m_isMoving;
    private bool m_canJump;
    private InputAction m_interact;
    private InputAction m_Inventory;
    private PickableItem m_currentHighlight;

    private LayerMask m_craftableLayer;

    
    
    private void Awake()
    {
        m_body = GetComponent<Rigidbody>();    
        m_inputAction = InputSystem.actions;
        m_interact = m_inputAction.FindAction("Interact");
        if(PlayerManager.Instance != null) 
        {
            PlayerManager.Instance.SetPlayer(gameObject.transform);
        }
        else
        {
            StartCoroutine(SetPlayerAfterPLayerManagerIsInitialize());
        }

    }

    private IEnumerator SetPlayerAfterPLayerManagerIsInitialize()
    {
        while (PlayerManager.Instance == null)
        {
            yield return null;
        }
        PlayerManager.Instance.SetPlayer(gameObject.transform);
    }

    public void OnInventory(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            m_Inventory = m_inputAction.FindAction("Inventory");
            if (m_Inventory.WasPressedThisFrame())
            {
                
                PlayerManager.Instance.ShowInventory();
            }

        }
    }

    

    public void OnMove(InputAction.CallbackContext context)
    {
        m_movementInput = context.ReadValue<Vector2>();
        m_isMoving = m_movementInput != Vector2.zero;
        m_jumpAction = context.ReadValue<Vector2>();


    }

    public void OnJump(InputAction.CallbackContext context)
    {

        m_jumpAction = context.ReadValue<Vector2>();

    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 cameraFormardNoX = new Vector3(Camera.allCameras[0].transform.forward.x,0, Camera.allCameras[0].transform.forward.z);
        transform.LookAt(cameraFormardNoX * DIRECTION);
        
        Vector3 calculatedVelocity = m_body.linearVelocity;
        calculatedVelocity.x = m_movementInput.x * m_speed;
        calculatedVelocity.z = m_movementInput.y * m_speed;
        m_body.linearVelocity = (transform.forward * calculatedVelocity.z + transform.right * calculatedVelocity.x + m_body.linearVelocity.y * Vector3.up);

         Vector3 move = Camera.allCameras[0].transform.forward * Input.GetAxis("Vertical") + Camera.allCameras[0].transform.right * Input.GetAxis("Horizontal");
        
       
        if (m_canJump)
        {
            m_body.AddForceAtPosition(new Vector2(0, m_jumpForce), Vector2.up, ForceMode.Impulse);
        }
        m_cameraFollow.UpdateCameraLogic();
    }

    private void LateUpdate()
    {
        Ray rayFromCamera = Camera.allCameras[0].ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        
        Debug.DrawRay(rayFromCamera.origin, rayFromCamera.direction * m_maxDistance, Color.red);
        Debug.DrawRay(m_body.position, m_body.transform.forward * m_maxDistance, Color.green);
        if (Physics.Raycast(rayFromCamera, out hitInfo, m_maxDistance))
        {
            HighLightPickable(hitInfo);
            if (m_interact.WasPressedThisFrame())
            {
                if (hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Pickable"))
                {
                    m_currentHighlight.Interact();

                    // collect le gameObject
                    //PlayerManager.Instance.AddItem(hitInfo.transform.gameObject.GetComponent<PickableItem>().m_item);
                    //Destroy(hitInfo.transform.gameObject);
                }
                else if (hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Interactable"))
                {
                    hitInfo.transform.gameObject.GetComponent<Interactible>().Interact();
                }
            }
            
        }
        else
        {
            //do nothing
        }
            
        
    }

    private void HighLightPickable(RaycastHit hitInfo)
    {
        if (hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Pickable"))
        {
            if(m_currentHighlight != null && m_currentHighlight != hitInfo.transform.gameObject.GetComponent<PickableItem>())
            {
                m_currentHighlight.UnHighlight();
            }
            m_currentHighlight = hitInfo.transform.gameObject.GetComponent<PickableItem>();
            m_currentHighlight.Highlight(m_objectHightlightMaterial);
        }
        else
        {
            if(m_currentHighlight != null)
            {
                m_currentHighlight.UnHighlight();
                m_currentHighlight = null;
            }
        }
    }
}
