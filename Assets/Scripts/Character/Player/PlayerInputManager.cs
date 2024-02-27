using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NGD
{
    public class PlayerInputManager : MonoBehaviour
    {
        public static PlayerInputManager instance;

        PlayerControls playerControls;

        [SerializeField] Vector2 movementInput;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            DontDestroyOnLoad(gameObject);

            // WHEN THE SCENE CHANGES, RUN THIS LOGIC
            SceneManager.activeSceneChanged += OnSceneChange;

            instance.enabled = false;
        }

        private void OnSceneChange(Scene oldScene, Scene newScene)
        {
            // IF WE ARE LOADING INTO OUR WORLD SCENE, ENABLE OUR PLAYER CONTROLS
            if (newScene.buildIndex == WorldSaveGameManager.instance.GetWorldSceneIndex()) 
            {
                instance.enabled = true;
            }
            // OTHERWISE WE MUST BE AT THE MAIN MENU, DISABLE OUR PLAYER CONTROLS
            // THIS IS SO OUR PLAYER CAN'T MOVE AROUND IF WE ENTER THINGS LIKE CHARACTER CREATION MENU ETC
            else
            {
                instance.enabled = false;
            }
        }

        private void OnEnable()
        {
            if (playerControls == null)
            {
                playerControls = new PlayerControls();

                playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            }

            playerControls.Enable();
        }

        private void OnDestroy()
        {
            // IF WE DESTROY THE OBJECT, UNSUBSCRIBE FROM THE EVENT
            SceneManager.activeSceneChanged -= OnSceneChange;
        }
    }
}

