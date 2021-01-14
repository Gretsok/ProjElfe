/// <summary>
/// To be references inside a NavigationState
/// </summary>
public interface INavigationPosition
{
    
    void OnSelected();
    /// <summary>
    /// Call it in Awake Method to set it to unselected when starting
    /// </summary>
    void OnUnselected();
}
