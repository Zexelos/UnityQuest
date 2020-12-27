using UnityEngine;

[CreateAssetMenu(fileName = "Quest", menuName = "ScriptableObjects/Quest", order = 1)]
public class Quest : ScriptableObject
{
    public int Reward => reward;
    public string Name => name;
    public string Description => description;
    public int ID => id;

    [SerializeField] private int reward = default;
    [SerializeField] private new string name = default;
    [SerializeField] private string description = default;
    [SerializeField] private int id = default;

    public virtual void OnFinished()
    {
    }

    public virtual void OnStart()
    {
    }

    public virtual void OnUpdated()
    {
    }
}
