using UnityEngine;
using UnityEngine.UI;

public class UISceneController : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private DinosaurSwitcher dinosaurSwitcher;
    [SerializeField] private DinosaurInfoPanel infoPanel;
    [SerializeField] private Slider humanHeightSlider;
    [SerializeField] private HumanScaleController humanScaleController;
    [SerializeField] private Button nextButton;
    [SerializeField] private Button prevButton;

    private int currentIndex;

    private void Awake()
    {
        if (nextButton != null) nextButton.onClick.AddListener(ShowNext);
        if (prevButton != null) prevButton.onClick.AddListener(ShowPrev);
        if (humanHeightSlider != null) humanHeightSlider.onValueChanged.AddListener(UpdateHumanHeight);
        infoPanel?.Clear();
    }

    private void Start()
    {
        currentIndex = 0;
        dinosaurSwitcher?.ShowByIndex(currentIndex);
        if (dinosaurSwitcher != null)
        {
            infoPanel?.UpdateInfo(dinosaurSwitcher.CurrentEntry);
        }
    }

    private void OnDestroy()
    {
        if (nextButton != null) nextButton.onClick.RemoveListener(ShowNext);
        if (prevButton != null) prevButton.onClick.RemoveListener(ShowPrev);
        if (humanHeightSlider != null) humanHeightSlider.onValueChanged.RemoveListener(UpdateHumanHeight);
    }

    public void HandleDinosaurChanged(DinosaurEntry entry)
    {
        infoPanel?.UpdateInfo(entry);
    }

    private void ShowNext()
    {
        currentIndex++;
        WrapIndex();
        dinosaurSwitcher?.ShowByIndex(currentIndex);
    }

    private void ShowPrev()
    {
        currentIndex--;
        WrapIndex();
        dinosaurSwitcher?.ShowByIndex(currentIndex);
    }

    private void WrapIndex()
    {
        if (dinosaurSwitcher == null)
        {
            currentIndex = 0;
            return;
        }

        int count = dinosaurSwitcher.Count;
        if (count <= 0)
        {
            currentIndex = 0;
            return;
        }

        if (currentIndex < 0)
        {
            currentIndex = count - 1;
        }
        else if (currentIndex >= count)
        {
            currentIndex = 0;
        }
    }

    private void UpdateHumanHeight(float value)
    {
        if (humanScaleController == null)
        {
            return;
        }

        humanScaleController.HeightMeters = Mathf.Lerp(1.3f, 2.0f, value);
    }
}
