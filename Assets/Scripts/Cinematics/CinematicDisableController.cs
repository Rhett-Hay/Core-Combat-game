using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace RPG.Cinematics
{
    public class CinematicDisableController : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            GetComponent<PlayableDirector>().played += DisableControl;
            GetComponent<PlayableDirector>().stopped += EnableControl;
        }

        void DisableControl(PlayableDirector director)
        {
            print("DisableControl");
        }

        void EnableControl(PlayableDirector director)
        {
            print("EnableControl");
        }
    }
}
