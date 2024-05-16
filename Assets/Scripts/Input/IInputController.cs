using System;
using UnityEngine;

    public interface IInputController
    {
       Vector3 GetMoveDiraction();
       Vector3 GetRotationDiraction();
       
       float y { get; set; }
       float z { get; set; }

       bool Fire();
    }
