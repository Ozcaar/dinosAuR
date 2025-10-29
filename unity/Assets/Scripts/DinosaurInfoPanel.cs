using TMPro;
using UnityEngine;

public class DinosaurInfoPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text nameLabel;
    [SerializeField] private TMP_Text heightLabel;
    [SerializeField] private TMP_Text lengthLabel;
    [SerializeField] private TMP_Text dietLabel;
    [SerializeField] private TMP_Text periodLabel;

    public void UpdateInfo(DinosaurEntry entry)
    {
        if (entry == null)
        {
            Clear();
            return;
        }

        if (nameLabel != null) nameLabel.text = entry.DisplayName;
        if (heightLabel != null) heightLabel.text = $"Altura: {entry.HeightMeters:0.0} m";
        if (lengthLabel != null) lengthLabel.text = $"Longitud: {entry.LengthMeters:0.0} m";
        if (dietLabel != null) dietLabel.text = $"Dieta: {entry.Diet}";
        if (periodLabel != null) periodLabel.text = $"Periodo: {entry.Period}";
    }

    public void Clear()
    {
        if (nameLabel != null) nameLabel.text = "";
        if (heightLabel != null) heightLabel.text = "";
        if (lengthLabel != null) lengthLabel.text = "";
        if (dietLabel != null) dietLabel.text = "";
        if (periodLabel != null) periodLabel.text = "";
    }
}
