using DefaultNamespace.Listeners;
using Player;
using UnityEngine;

public class Rescuer : MonoBehaviour, IGameStartListener, IGameUpdateListener
{
   [SerializeField] private AtomicVarible<float> _health;

   public AtomicVarible<float> _moveSpeed;
   public AtomicVarible<float> _rotationSpeed;
   public AtomicVarible<Vector3> _moveDiraction;
   public AtomicVarible<Vector3> _rotationDiraction;

   private Movement _movement;
   private Rotation _rotation;

   public void OnStart()
   {
      _movement = new Movement(_moveSpeed, _moveDiraction, transform);
      _rotation = new Rotation(_rotationDiraction, _rotationSpeed, transform);
   }

   public void OnUpdate(float deltaTime)
   {
      _movement.Update();
      _rotation.Update();
   }
}
