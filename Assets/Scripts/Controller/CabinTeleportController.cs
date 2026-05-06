using UnityEngine;

public class CabinTeleportController : MonoBehaviour
{
    [SerializeField] private Transform m_teleportPointOne;
   // [SerializeField] private Transform m_teleportPointTwo;
  //  [SerializeField] private Transform m_teleportPointThree;
   // [SerializeField] private Transform m_cabin;

    private int m_wasTeleport = 0;

    public void Teleport()
    {
        if(m_wasTeleport == 0)
        {
            gameObject.transform.position = m_teleportPointOne.position;
            m_wasTeleport++;
        }
        //if(m_wasTeleport == 1)
        //{
        //    m_cabin.transform.position = m_teleportPointTwo.position;
        //    m_wasTeleport++;
        //}
        //if(m_wasTeleport == 2)
        //{
        //    m_cabin.transform.position = m_teleportPointThree.position;
        //    m_wasTeleport++;
        //}
    }
}
