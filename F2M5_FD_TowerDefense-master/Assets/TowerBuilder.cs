using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private TowerBuildUI Tiles;
    [SerializeField] private LayerMask _layer;
    private Tile _selectedTile = null;

    void Update()
    {
        if (Input.GetMouseButton(0) && _selectedTile == null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, _layer))
            {
                Tile tile = hit.transform.GetComponent<Tile>();
                if (!tile.HasProperty)
                {
                    Tiles.Show(true);
                    _selectedTile = tile;
                }
                else
                {
                    //Show Upgrade Menu
                }
               
            } else if(Input.GetMouseButtonDown(0) && _selectedTile != null)
            {
                _selectedTile = null;
                Tiles.Show(false);
            }
        }
    }
    public void BuildTower(OtherScript tower)
    {
        if (_selectedTile.HasProperty)
        {
            return;
        }
        Vector3 Spawnposition = new Vector3(_selectedTile.transform.position.x, 0.08f, _selectedTile.transform.position.z);
        Instantiate(tower, Spawnposition, Quaternion.identity);
        _selectedTile.HasProperty = true;
        Tiles.Show(false);
    }

    public void BuildingTower(TowerLookAtEnemyatCertainRange Towers)
    {
        if (_selectedTile.HasProperty)
        {
            return;
        }
        Vector3 spawn = new Vector3(_selectedTile.transform.position.x, 0.08f, _selectedTile.transform.position.z);
        Instantiate(Towers, spawn, Quaternion.identity);
        _selectedTile.HasProperty = true;
        Tiles.Show(false);
    }

    public void CanonSplashing(CanonSplash TowerSplash)
    {
        if (_selectedTile.HasProperty)
        {
            return;
        }
        Vector3 spawning = new Vector3(_selectedTile.transform.position.x, 0.08f, _selectedTile.transform.position.z);
        Instantiate(TowerSplash, spawning, Quaternion.identity);
        _selectedTile.HasProperty = true;
        Tiles.Show(false);
    }
}
