using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject
{
    private GridSystem gridSystem;
    private GridPosition gridPosition;
    private List<Unit_Movement> unitList;

    //public constructor
    public GridObject(GridSystem gridSystem, GridPosition gridPosition)
    {
        this.gridSystem = gridSystem;
        this.gridPosition = gridPosition;
        unitList = new List<Unit_Movement>();
    }

    public override string ToString()
    {
        string unitString = " "; 
        foreach(Unit_Movement unit in unitList){
            unitString += unit + "\n";

        }
        return gridPosition.ToString() + "\n" + unitString;
    }

    public void AddUnit(Unit_Movement unit)
    {
        unitList.Add(unit);
    }

    public void RemoveUnit(Unit_Movement unit){
        unitList.Remove(unit);
    }

    public List<Unit_Movement> GetUnitList()
    {
        return unitList;
    }


}
