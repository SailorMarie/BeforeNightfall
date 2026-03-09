using UnityEngine;

public class PickableItem : MonoBehaviour
{
    [SerializeField] public Items m_item;

    public void Interact()
    {
        PlayerManager.Instance.AddItem(m_item);
        Destroy(gameObject);
    }
}
