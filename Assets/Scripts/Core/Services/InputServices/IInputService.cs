namespace DefaultNamespace.Core.Services.InputServices
{
    public interface IInputService
    {
        bool IsAttacking { get; }
        bool IsJumping { get; }
    }
}