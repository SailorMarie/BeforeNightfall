using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] protected BoxCollider m_teleportZone;
    [SerializeField] protected Transform m_destination;

    public virtual void Init(GameController gameController)
    {
        
    }
}
