using System;
using UnityEngine;

    [Serializable]
    public class KeyboardInput: InputController
    {
        
        public float y { get; set; }
        public float z { get; set; }
        
        public override Vector3 GetMoveDiraction()
        {
            if (Input.GetKey(KeyCode.W))
            {
                z = 1;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                z = -1;
            }
            else
            {
                z = 0;
            }
            
            

            return new Vector3(0, 0, z);
        }

        public override Vector3 GetRotationDiraction()
        {
            if (Input.GetKey(KeyCode.A))
            {
                y = -1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                y = 1;
            }
            else
            {
                y = 0;
            }

            return new Vector3(0, y, 0);
        }

        public override bool Fire()
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                return true;
            }

            return false;
        }
    }
