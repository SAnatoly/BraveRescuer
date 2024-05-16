using DefaultNamespace.Listeners;
using UnityEngine;

public class InputManager: MonoBehaviour, IGameUpdateListener, IGameStartListener
{

   [SerializeField] private Rescuer _rescuer;
   [SerializeField] private Spray.Spray _spray;
   
   private InputController _inputSources;

   public void OnStart()
   {
      _inputSources = new KeyboardInput();
   }
   
   public void OnUpdate(float deltaTime)
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
