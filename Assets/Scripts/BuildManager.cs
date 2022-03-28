using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    GameObject turretSpawnLocation;
    GameObject buildEffectSpawnLocation;
    void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        turretSpawnLocation = GameObject.Find("TurretsSpawnHere");
        buildEffectSpawnLocation = GameObject.Find("BuildEffectSpawnHere");
    }

    public GameObject standardTurretPrefab;
    public GameObject anotherTurretPrefab;

    public GameObject buildEffect;

    private TurrentBlueprint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough money to build that!");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity, turretSpawnLocation.transform);
        node.turret = turret;

        GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity, buildEffectSpawnLocation.transform);
        Destroy(effect, 5f);

        Debug.Log("Turret build! Money left:" + PlayerStats.Money);
    }

    public void SelectTurretToBuild(TurrentBlueprint turret)
    {
        turretToBuild = turret;
    }
}
