using System;
using UnityEngine;

    [Serializable]
    public abstract class InputController: IInputController
    {
        public abstract Vector3 GetMoveDiraction();
        public abstract Vector3 GetRotationDiraction();

        public float y { get; set; }
        public float z { get; set; }
        public abstract bool Fire();

    }
