using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NGD
{
    public class CharacterManager : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}
