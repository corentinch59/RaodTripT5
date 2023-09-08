using UnityEngine;

public class TrashOverload : IEvent
{
    public void BeginEvent()
    {
        Debug.Log("Trash Overload Began");
        UIManager.Instance.TrashOverloadPopup.SetActive(true);
        UIManager.Instance.BtnTrashMat.SetColor("_EmissionColor", new Color(0.0f,1.0f,0f));
        UIManager.Instance.BtnTrashMat.SetColor("_BaseColor", new Color(0.0f,1.0f,0f));
    }

    public void CompleteEvent()
    {
        Debug.Log("Trash Overload Completed");
        AudioManager.Instance.PlaySound("Trash");
        UIManager.Instance.TrashOverloadPopup.SetActive(false);
        UIManager.Instance.BtnTrashMat.SetColor("_EmissionColor", new Color(1.0f, 1.0f, 1.0f));
        UIManager.Instance.BtnTrashMat.SetColor("_BaseColor", new Color(1.0f, 1.0f, 1.0f));
    }

    public void FailedEvent()
    {
        throw new System.NotImplementedException();
    }
}
