using System;
using DefaultNamespace.Listeners;
using UnityEngine;

public class InputManager: MonoBehaviour
{

   [SerializeField] private Rescuer _rescuer;
   [SerializeField] private Spray.Spray _spray;
   
   private InputController _inputSources;

   private void Awake()
   {
      _inputSources = new KeyboardInput();
   }

   public void Update()
   {
      MoveRescuer();
      RotateRescuer();
      SpreyFire();
   }
 
   private void MoveRescuer()
   {
      _rescuer._moveDiraction.Value = _inputSources.GetMoveDiraction();
   }

   private void RotateRescuer()
   {
      _rescuer._rotationDiraction.Value = _inputSources.GetRotationDiraction();
   }

   private void SpreyFire()
   {
      if (_inputSources.Fire())
      {
         _spray.ActivateSpray();
      }
      else
      {
         _spray.DiactivateSpray();
      }
   }
}
