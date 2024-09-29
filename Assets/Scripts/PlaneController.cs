using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Mathematics.Week6
{
    public class PlaneController : MonoBehaviour
    {
        [SerializeField] private GameManager gameManager;
        private Rigidbody myRBD;
        [SerializeField] private float velocityModifier = 5f;
        [SerializeField] private float rotationAngle = 35f;
        [SerializeField] private float rotationSmooth = 5f;
        [SerializeField] private Animator optionsAnimator;
        [SerializeField] public int life = 3;
        private bool isOptionsActive = false;

        private Vector2 inputMovement;
        private Quaternion targetRotation;

        private void Awake()
        {
            myRBD = GetComponent<Rigidbody>();
            gameManager.UpdateLife(life);
        }
        void Update()
        {
            if (gameManager.isGameActive) 
            {
                UpdateRotation();
            }
        }
        public void OnMove(InputAction.CallbackContext context)
        {
            if (gameManager.isGameActive) 
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
        }
        private void UpdateRotation()
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSmooth * Time.deltaTime);
        }
        public void OnOptions(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                isOptionsActive = optionsAnimator.GetBool("IsOptions");
                optionsAnimator.SetBool("IsOptions", !isOptionsActive);
                if (!isOptionsActive)
                {
                    gameManager.PauseGame();
                }
                else
                {
                    gameManager.ResumeGame();
                }
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Trash"))
            {
                life--;
                gameManager.UpdateLife(life);
                gameManager.LoseLife();
                if (life <= 0)
                {
                    gameManager.LoseLife();
                }
                Destroy(other.gameObject);
            }   
        }
    }
}
