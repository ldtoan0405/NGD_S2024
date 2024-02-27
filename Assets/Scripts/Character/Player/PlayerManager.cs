using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NGD
{
    public class PlayerManager : CharacterManager
    {
        PlayerLocomotionManager playerLocomotionManager;
        protected override void Awake()
        {
            base.Awake();

            // DO MORE STUFF, ONLY FOR THE PLAYER
            playerLocomotionManager = GetComponent<PlayerLocomotionManager>();
        }

        protected override void Update()
        {
            base.Update();

            // HANDLE ALL MOVEMENT
            playerLocomotionManager.HandleAllMovement();
        }
    }

}