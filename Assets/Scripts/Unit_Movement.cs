using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_Movement : MonoBehaviour
{
    [SerializeField] private Animator unitAnimator;
    private Vector3 targetPosition;
    private string isWalking = "IsWalking";
    private GridPosition gridPosition;
    [SerializeField] private float moveSpeed = 1f;
    private float stopDistance = 0.01f;

    [SerializeField, Range(1, 10)] private float rotateSpeed;

    private void Start()
    {
        gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        LevelGrid.Instance.AddUnitAtGridPosition(gridPosition, this);
    }
    private void Awake()
    {
        targetPosition = transform.position;
    }
    private void Update()
    {

        Vector3 moveDirection = (targetPosition - transform.position).normalized;
        if (Vector3.Distance(transform.position, targetPosition) > stopDistance)
        {
            transform.position += moveDirection * Time.deltaTime * moveSpeed;

            transform.forward = Vector3.Lerp(transform.forward, moveDirection, rotateSpeed * Time.deltaTime);
            unitAnimator.SetBool(isWalking, true);
        }
        else
        {
            unitAnimator.SetBool(isWalking, false);
        }

        GridPosition newgridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        if(newgridPosition != gridPosition){
            LevelGrid.Instance.UnitMoveGridPosition(this, gridPosition, newgridPosition);
            gridPosition = newgridPosition; 
        }


    }
    public void Move(Vector3 targetPosition)
    {
        this.targetPosition = targetPosition;
    }


}
