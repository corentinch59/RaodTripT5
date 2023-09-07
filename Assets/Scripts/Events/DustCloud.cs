using UnityEngine;

public class DustCloud : IEvent
{
    public void BeginEvent()
    {
        Debug.Log("Dust Began");
        UIManager.Instance.Dusts.SetActive(true);
    }

    public void CompleteEvent()
    {
        Debug.Log("Dust Completed");
        UIManager.Instance.Dusts.SetActive(false);
    }

    public void FailedEvent()
    {
        throw new System.NotImplementedException();
    }
}
