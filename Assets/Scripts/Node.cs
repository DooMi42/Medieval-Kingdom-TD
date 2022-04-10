using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    GameObject turretSpawnLocation;
    GameObject buildEffectSpawnLocation;

    private Renderer rend;

    private Color startColor;

    BuildManager buildManager;
    void Start()
    {
        turretSpawnLocation = GameObject.Find("TurretsSpawnHere");
        buildEffectSpawnLocation = GameObject.Find("BuildEffectSpawnHere");

        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;

    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
            return;

        BuildTurret(buildManager.GetTurretToBuild());
    }
    void BuildTurret (TurretBlueprint blueprint)
    {
            if (PlayerStats.Money < blueprint.cost)
            {
                Debug.Log("Not enough money to build that!");
                return;
            }

            PlayerStats.Money -= blueprint.cost;

            GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity, turretSpawnLocation.transform);
            turret = _turret;

            turretBlueprint = blueprint;

            GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity, buildEffectSpawnLocation.transform);
            Destroy(effect, 5f);

            Debug.Log("Turret build!");
    }
    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough money to upgrade that!");
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;

        // Destroy old junky tower and make space for new upgraded one
        Destroy(turret);

        // Building amazing upgraded tower
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity, turretSpawnLocation.transform);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity, buildEffectSpawnLocation.transform);
        Destroy(effect, 5f);

        isUpgraded = true;

        Debug.Log("Turret upgraded!");
    }
    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount();

        //Spawn sell effect
        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity, buildEffectSpawnLocation.transform);
        Destroy(effect, 5f);

        Destroy(turret);
        turretBlueprint = null;
    }
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }

    }
    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

}
