using UnityEngine;
using UnityEngine.UI;

public class Marian : QuestGiver
{
    [SerializeField] Button _buttonInteract = default;

    protected override bool SubscribePlayer(Collider other)
    {
        if (!base.SubscribePlayer(other))
            return false;

        _buttonInteract.gameObject.SetActive(true);
        _buttonInteract.onClick.RemoveAllListeners();
        _buttonInteract.onClick.AddListener(SubscribeQuests);
        //_buttonInteract.onClick.AddListener(subscribedPlayer.ShowQiestList);
        _buttonInteract.onClick.AddListener(subscribedPlayer.DrawButtons);

        return true;
    }

    protected override void UnsubscribePlayer(Collider other)
    {
        UnsubscribeQuests();
        base.UnsubscribePlayer(other);
        _buttonInteract.gameObject.SetActive(false);
    }
}
