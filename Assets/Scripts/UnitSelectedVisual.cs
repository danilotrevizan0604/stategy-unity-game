using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectedVisual : MonoBehaviour
{
    [SerializeField] private Unit_Movement Unit;

    private MeshRenderer meshRenderer;
    private void Awake() {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start() {
        UnitActionSystem.Instance.OnSelectedUnitChanged += UnitActionSystem_OnSelectedUnitChange;

        UpdateVisual();
    }

    private void UnitActionSystem_OnSelectedUnitChange(object sender, EventArgs empty){
        UpdateVisual();
        
    }
    private void UpdateVisual(){
        if(UnitActionSystem.Instance.GetSelectecUnit() == Unit){
            meshRenderer.enabled = true;
        }
        else{
            meshRenderer.enabled = false;
        }
    }


}
