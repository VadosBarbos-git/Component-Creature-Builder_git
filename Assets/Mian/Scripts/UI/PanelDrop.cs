using UnityEngine;
using UnityEngine.EventSystems;

public class PanelDrop : MonoBehaviour, IDropHandler
{
    [SerializeField] private ComponentUIController UiController;
    [SerializeField] private PanelSide side;
    public void OnDrop(PointerEventData eventData)
    {
        var cell = eventData.pointerDrag.GetComponent<Cell>(); 
        if (cell != null && cell.GetEntityComponent() != null)
        {
            UiController.DropCellOn(side, cell.GetEntityComponent());
        }
    }


}
