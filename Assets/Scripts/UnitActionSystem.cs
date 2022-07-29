using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{
    public static UnitActionSystem Instance { get; private set;}   
    public event EventHandler OnSelectedUnitChanged;
    [SerializeField] private Unit_Movement selectedUnit;
    [SerializeField] private LayerMask UnitMask;
    
    private void Awake() {
        if(Instance != null){
            Debug.LogError("There is more than on UnitActionSystem!" + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    private void Update() {

        if(Input.GetMouseButtonDown(0)){
            if(TryHandleUnitSelection()) return;
            selectedUnit.Move(MouseWorld.GetPosition());
        } 
        
    }

    private bool TryHandleUnitSelection(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, UnitMask)){
           if(raycastHit.transform.TryGetComponent<Unit_Movement>(out Unit_Movement unit)){
                SetSelectedUnit(unit);
                return true;
           }    
        }
        return false;
    }

    private void SetSelectedUnit(Unit_Movement unit){
        selectedUnit = unit;
        
        //null check using the ? and then invoke to create the event
        OnSelectedUnitChanged?.Invoke(this, EventArgs.Empty);
    }

    public Unit_Movement GetSelectecUnit(){
        return selectedUnit;
    }
    
}
