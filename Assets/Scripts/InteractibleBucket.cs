using UnityEngine;

public class InteractibleBucket : Interactible
{
    [SerializeField] private Items m_itemToDrop;

    public override void Interact()
    {
        base.Interact();
        PlayerManager.Instance.DropItem(m_itemToDrop, transform.position);
    }
}
