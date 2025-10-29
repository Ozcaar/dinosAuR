using System;
using UnityEngine;
using UnityEngine.Events;

public class DinosaurSwitcher : MonoBehaviour
{
    [SerializeField] private DinosaurCatalogue catalogue;
    [SerializeField] private Transform spawnParent;
    [SerializeField] private DinosaurEntryEvent onDinosaurChanged;

    private GameObject currentInstance;
    private DinosaurEntry currentEntry;

    public DinosaurEntry CurrentEntry => currentEntry;
    public int Count => catalogue != null ? catalogue.Dinosaurs.Count : 0;

    public void ShowByIndex(int index)
    {
        if (Count == 0)
        {
            Debug.LogWarning("Catálogo de dinosaurios no configurado.");
            return;
        }

        index = Mathf.Clamp(index, 0, Count - 1);
        ShowEntry(catalogue.Dinosaurs[index]);
    }

    public void ShowById(string id)
    {
        if (catalogue == null)
        {
            Debug.LogWarning("Catálogo de dinosaurios no configurado.");
            return;
        }

        var entry = catalogue.GetById(id);
        if (entry == null)
        {
            Debug.LogWarning($"No se encontró dinosaurio con id {id}.");
            return;
        }

        ShowEntry(entry);
    }

    private void ShowEntry(DinosaurEntry entry)
    {
        if (entry == currentEntry)
        {
            return;
        }

        if (currentInstance != null)
        {
            Destroy(currentInstance);
        }

        if (entry.Prefab == null)
        {
            Debug.LogWarning($"El prefab para {entry.DisplayName} no está asignado.");
            return;
        }

        currentInstance = Instantiate(entry.Prefab, spawnParent != null ? spawnParent : transform);
        currentEntry = entry;
        onDinosaurChanged?.Invoke(entry);
    }
}

[Serializable]
public class DinosaurEntryEvent : UnityEvent<DinosaurEntry>
{
}
