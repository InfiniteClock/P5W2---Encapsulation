using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Monobehaviour script used to create Sim entities.
public class SimManager : MonoBehaviour
{
    [Header("The actually useful stuff")]
    public List<SimData> sims = new List<SimData>();
    [SerializeField] private GameObject simPrefab;
    public Transform simsHolder;

    [Header("Experimentation stuff")]
    [Range(5f, 30f)] public float rangeEx;
    public int getter {  get; private set; }

    /// <summary>
    /// On initialization, the SimManager will create Sim entities for each instance of SimData it has stored.
    /// </summary>
    void Start()
    {
        foreach (SimData simData in sims)
        {
            CreateSimEntity(simData);
        }
    }
    /// <summary>
    /// Given data about a Sim, it creates the entity associated with that data
    /// </summary>
    /// <param name="simData">Data class used for propagating the details of a Sim when creating them in the simulation.</param>
    public void CreateSimEntity(SimData simData)
    { 
        GameObject simObject = Instantiate(simPrefab, simsHolder);
        Sim sim = simObject.GetComponent<Sim>();
        sim.Initialize(simData);
    }

}
