using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DinosaurCatalogue", menuName = "DinoScale/Dinosaur Catalogue", order = 0)]
public class DinosaurCatalogue : ScriptableObject
{
    [SerializeField]
    private List<DinosaurEntry> dinosaurs = new List<DinosaurEntry>();

    public IReadOnlyList<DinosaurEntry> Dinosaurs => dinosaurs;

    public DinosaurEntry GetById(string id)
    {
        return dinosaurs.Find(d => string.Equals(d.Id, id, StringComparison.OrdinalIgnoreCase));
    }
}

[Serializable]
public class DinosaurEntry
{
    [SerializeField] private string id;
    [SerializeField] private string displayName;
    [SerializeField] private GameObject prefab;
    [Header("Características físicas")]
    [SerializeField] private float heightMeters;
    [SerializeField] private float lengthMeters;
    [Header("Información educativa")]
    [SerializeField] private string diet;
    [SerializeField] private string period;

    public string Id => id;
    public string DisplayName => displayName;
    public GameObject Prefab => prefab;
    public float HeightMeters => heightMeters;
    public float LengthMeters => lengthMeters;
    public string Diet => diet;
    public string Period => period;
}
