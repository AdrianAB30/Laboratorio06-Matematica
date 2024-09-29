using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement_Trash : MonoBehaviour
{
    [SerializeField] private SOs_TrashData trashData; 

    private void Update()
    {
        MoveForward();
    }
    private void MoveForward()
    {
        transform.position -= transform.forward * trashData.speed * Time.deltaTime; 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Limite"))
        {
            Destroy(this.gameObject);
        }
    }
}
