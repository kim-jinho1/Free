using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicItem : MonoBehaviour
{
    public enum ItemRating
    {
        Normal,
        Uncommon,
        Rare,
        Hero,
        Artifact,
        Ancient,
        Myth
    }
}
