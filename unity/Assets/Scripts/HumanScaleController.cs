using UnityEngine;

public class HumanScaleController : MonoBehaviour
{
    [SerializeField] private Transform humanRoot;
    [SerializeField, Tooltip("Altura del humano en metros.")] private float heightMeters = 1.75f;

    public float HeightMeters
    {
        get => heightMeters;
        set
        {
            heightMeters = Mathf.Clamp(value, 1.0f, 2.2f);
            ApplyScale();
        }
    }

    private void OnValidate()
    {
        ApplyScale();
    }

    private void ApplyScale()
    {
        if (humanRoot == null)
        {
            humanRoot = transform;
        }

        float scale = heightMeters / 1.75f;
        humanRoot.localScale = Vector3.one * scale;
    }
}
