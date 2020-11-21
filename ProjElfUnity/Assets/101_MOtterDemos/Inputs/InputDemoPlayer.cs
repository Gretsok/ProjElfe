using MOtter;
using UnityEngine;

public class InputDemoPlayer : MonoBehaviour
{
    private int m_playerIndex = -1;
    private PlayerInputsActions m_actions;
    Vector2 moveInputs = Vector2.zero;

    public void Init(int playerIndex)
    {
        m_playerIndex = playerIndex;


        SetUpInputs();
    }

    public void SetUpInputs()
    {
        m_actions = MOtterApplication.GetInstance().PLAYERPROFILES.GetPlayerInputAction<PlayerInputsActions>(m_playerIndex);

        /*m_actions.GAMEPLAY.MOVE.performed += MOVE_performed;
        m_actions.GAMEPLAY.MOVE.canceled += MOVE_canceled;*/
    }

    private void MOVE_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        moveInputs = Vector2.zero;
    }

    public void UpdatePlayer()
    {
        Vector3 direction = new Vector3(moveInputs.x, 0, moveInputs.y);
        transform.position += direction * Time.deltaTime;

    }

    private void MOVE_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        moveInputs = obj.ReadValue<Vector2>();
        
    }

    public void CleanUpInputs()
    {
        /*m_actions.GAMEPLAY.MOVE.performed -= MOVE_performed;
        m_actions.GAMEPLAY.MOVE.canceled -= MOVE_canceled;*/


    }
}
