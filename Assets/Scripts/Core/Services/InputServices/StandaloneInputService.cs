using UnityEngine;

namespace DefaultNamespace.Core.Services.InputServices
{
    public class StandaloneInputService : IInputService
    {
        private const KeyCode Jump = KeyCode.Space;
        private const KeyCode Attack = KeyCode.D;
        
        public bool IsAttacking => Input.GetKeyDown(Attack);
        public bool IsJumping => Input.GetKeyDown(Jump);
    }
}