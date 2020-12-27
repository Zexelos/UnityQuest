using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class QuestWithGiverStatus
{
    public enum GiverQuestStatus
    {
        Start,
        Update,
        Finish
    }

    public Quest quest;
    public GiverQuestStatus Status;
}
