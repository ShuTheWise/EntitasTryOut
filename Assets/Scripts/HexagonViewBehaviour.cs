using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static HexagonType;
public class HexagonViewBehaviour : MonoBehaviour
{
    public Image image;
    [SerializeField] private HexDuet[] collection;
    [System.Serializable]
    private class HexDuet
    {
        public HexagonType type;
        public Sprite sprite;
        public Color color = Color.white;
    }
    internal void SetType(HexagonType value)
    {
        if (collection.Any())
        {
            var hexduet = collection.FirstOrDefault(x => x.type == value);
            if (hexduet != null)
            {
                image.sprite = hexduet.sprite;
                image.color = hexduet.color;
            }
        }
    }
}

