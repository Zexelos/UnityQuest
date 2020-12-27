using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    [SerializeField] protected List<QuestWithGiverStatus> _questWithGiverStatus;
    protected QuestManager subscribedPlayer = null;

    private void OnTriggerEnter(Collider other)
    {
        SubscribePlayer(other);
        Debug.Log("entered");
    }

    private void OnTriggerExit(Collider other)
    {
        UnsubscribePlayer(other);
        Debug.Log("left");
    }

    protected virtual bool SubscribePlayer(Collider other)
    {
        subscribedPlayer = other.GetComponent<QuestManager>();
        return (subscribedPlayer != null);
    }

    protected virtual void UnsubscribePlayer(Collider other)
    {
        if (other.CompareTag("Player"))
            subscribedPlayer = null;
    }

    protected void SubscribeQuests()
    {
        foreach (var item in _questWithGiverStatus)
        {
            subscribedPlayer.currentNPCQuestList.Add(item);
        }
    }

    protected void UnsubscribeQuests()
    {
        subscribedPlayer.currentNPCQuestList.Clear();
        subscribedPlayer.ClearQuestUI();
    }

    public virtual void StartQuest() { }

    public virtual void UpdateQuest() { }

    public virtual void FinishQuest() { }
}
