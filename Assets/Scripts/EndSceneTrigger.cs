using UnityEngine;

public class EndSceneTrigger : MonoBehaviour
{
   private EndGameController m_endGameController;

    public void Initialize(EndGameController endGameController)
    {
        m_endGameController = endGameController;
    }

    private void OnTriggerEnter(Collider other)
    {
        m_endGameController.OnEndGameReach?.Invoke();
    }
}
