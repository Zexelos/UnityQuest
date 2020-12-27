using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    [SerializeField] Button interactButton = default;
    [SerializeField] Button declineButton = default;
    [SerializeField] Button acceptButton = default;
    [SerializeField] GameObject scrollView = default;
    [SerializeField] GameObject scrollViewQuestDescription = default;
    [SerializeField] GameObject content = default;
    [SerializeField] Button buttonQuestListPrefab = default;
    [SerializeField] TMP_Text descriptionText = default;

    public List<QuestWithGiverStatus> activeQuestList = new List<QuestWithGiverStatus>();

    public List<QuestWithGiverStatus> currentNPCQuestList = new List<QuestWithGiverStatus>();

    public void DrawButtons()
    {
        scrollView.gameObject.SetActive(true);

        var buttonPrefabText = buttonQuestListPrefab.GetComponentInChildren<TMP_Text>();

        foreach (var item in currentNPCQuestList)
        {
            buttonPrefabText.text = item.quest.Name;
            var spawnedButton = Instantiate(buttonQuestListPrefab, content.transform);
            spawnedButton.gameObject.SetActive(true);
            spawnedButton.onClick.RemoveAllListeners();
            spawnedButton.onClick.AddListener(() => ShowQuestInfo(item));
            declineButton.onClick.RemoveAllListeners();
            declineButton.onClick.AddListener(DeclineQuest);
        }

        interactButton.gameObject.SetActive(false);
    }

    void ShowQuestInfo(QuestWithGiverStatus quest)
    {
        scrollView.gameObject.SetActive(false);
        scrollViewQuestDescription.gameObject.SetActive(true);
        descriptionText.text = quest.quest.Description;
        acceptButton.onClick.RemoveAllListeners();
        acceptButton.onClick.AddListener(() => AcceptQuest(quest));
    }

    public void ClearQuestUI()
    {
        var costam = content.GetComponentsInChildren<Button>().Where(x => x);

        foreach (var item in costam)
        {
            Destroy(item.gameObject);
        }

        scrollViewQuestDescription.gameObject.SetActive(false);
        scrollView.gameObject.SetActive(false);
    }

    void DeclineQuest()
    {
        scrollView.gameObject.SetActive(true);
        scrollViewQuestDescription.gameObject.SetActive(false);
    }

    void AcceptQuest(QuestWithGiverStatus quest)
    {
        if (!activeQuestList.Contains(quest))
        {
            activeQuestList.Add(quest);
            Debug.Log($"Quest {quest.quest.Name} has been added");
        }
        else
            Debug.Log("You already have this quest");
    }

    public void ShowQiestList()
    {
        foreach (var item in currentNPCQuestList)
        {
            Debug.Log(item.quest.Name);
        }
    }

    void ShowCurrentQuestList()
    {
        foreach (var item in activeQuestList)
        {
            Debug.Log(item.quest.Name);
        }
    }
}
