using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.CorgiEngine;
using System.IO;
using System;
using UnityEngine.XR;
using UnityEditor;

namespace RubbleManager
{
    public class RubbleManagement : MonoBehaviour
    {
        public bool isRubbleItemCollected;
        bool isEntering = false;
        // Start is called before the first frame update

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "RubbleItem")
            {
                isEntering = true;
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (isEntering && Input.GetKeyDown(KeyCode.F))
            {
                /*
                string originFlags = File.ReadAllText("Assets/Back_B/Scripts/Flags.txt");
                string[] flags = originFlags.Split('\n');
                flags[0] = "true";
                originFlags = "";
                foreach (string f in flags)
                {
                    originFlags = f + "\n";
                }
                Debug.Log(originFlags);
                File.WriteAllText("Assets/Back_B/Scripts/Flags.txt", originFlags);
                isEntering = false;
                */
                File.WriteAllText("Assets/Back_B/Scripts/Flags.txt", "true");
                isEntering = false;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.tag == "RubbleItem")
            {
                isEntering = false;
            }
        }

        public bool getIsRubbleItemCollected()
        {
            return isRubbleItemCollected;
        }

    }
}