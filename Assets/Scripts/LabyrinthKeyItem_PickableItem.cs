using UnityEngine;

public class LabyrinthKeyItem : PickableItem
{
    private LabyrinthController m_labyrinthController;
    public void Init(LabyrinthController labyrinthController)
    {
        m_labyrinthController = labyrinthController;
    }
    public override void Interact()
    {
        PlayerManager.Instance.AddItem(m_item);
        m_labyrinthController.OnForestKeyPickUp?.Invoke();
        Destroy(gameObject);
    }
}
