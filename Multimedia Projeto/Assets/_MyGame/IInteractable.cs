public interface IInteractable
{
    // Any script that uses this interface MUST have these two methods
    void Interact();
    string GetInteractPrompt(); 
}