using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Mathematics.Week6
{
    public class PlaneController : MonoBehaviour
    {
        private Rigidbody myRBD;
        [SerializeField] private float velocityModifier = 5f;
        [SerializeField] private float rotationAngle = 35f;
        [SerializeField] private float rotationSmooth = 5f;
        [SerializeField] private int life = 3;
        //public AudioSource audioDamage;
        //public AudioSource audioLose;
        //public TextMeshProUGUI textLife;

        private Vector2 inputMovement;
        private Quaternion targetRotation;

        private void Awake()
        {
            myRBD = GetComponent<Rigidbody>();
        }
        void Update()
        {
            UpdateRotation();
        }
        public void OnMove(InputAction.CallbackContext context)
        {
            inputMovement = context.ReadValue<Vector2>();

            myRBD.velocity = new Vector3(inputMovement.x * velocityModifier, inputMovement.y * velocityModifier, 0f);

            if (inputMovement.x > 0) 
            {
                targetRotation = Quaternion.Euler(0f, 0f, -rotationAngle);
            }
            else if (inputMovement.x < 0) 
            {
                targetRotation = Quaternion.Euler(0f, 0f, rotationAngle);
            }
            else if (inputMovement.y > 0)
            {
                targetRotation = Quaternion.Euler(-rotationAngle, 0f, 0f);
            }
            else if (inputMovement.y < 0) 
            {
                targetRotation = Quaternion.Euler(rotationAngle, 0f, 0f);
            }
            else
            {
                targetRotation = Quaternion.Euler(0f, 0f, 0f);
            }
        }
        private void UpdateRotation()
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSmooth * Time.deltaTime);
        }
    }
}
