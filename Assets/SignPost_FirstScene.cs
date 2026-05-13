using UnityEngine;

public class SignPost_FirstScene : MonoBehaviour
{
    [SerializeField] private Window tutoWindow;
    private TutoWindow currentTuto;
    public void OnTriggerEnter(Collider other)
    {
       currentTuto =  (TutoWindow)UIManager.Instance.OpenWindow(tutoWindow);   
    }

    public void OnTriggerExit(Collider other)
    {
        if (currentTuto != null)
        {
            currentTuto.Close();
            
        }
    }
}
