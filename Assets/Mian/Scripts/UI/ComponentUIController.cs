using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComponentUIController : MonoBehaviour
{
    [SerializeField] private GameObject _cellComponentPrefab; 
    [SerializeField] private PanelDrop _appliedPanel;
    [SerializeField] private PanelDrop _notAppliedPanel;
    [SerializeField] private DragCell _dragCell;
    private ComponentManager _managerController;
    public void Init(ComponentManager managerController)
    {
        _managerController = managerController;
        UpdateApplyedPanel(_managerController.GetAppliedComponents());
        UpdateNotApplyedPanel(_managerController.GetNotAppliedComponents());
    }
    public void DropCellOn(PanelSide side, ComponentDefinition component)
    {
        _managerController.PutComponentOnSide(side, component);
        UpdateApplyedPanel(_managerController.GetAppliedComponents());
        UpdateNotApplyedPanel(_managerController.GetNotAppliedComponents());
    }
    public void UpdateApplyedPanel(List<ComponentDefinition> components)
    {
        for (int i = _appliedPanel.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(_appliedPanel.transform.GetChild(i).gameObject);
        }
        foreach (var item in components)
        {
            var obj = Instantiate(_cellComponentPrefab, _appliedPanel.transform);
            obj.GetComponent<Cell>().SetCell(item, _dragCell);
        }
        StartCoroutine(FlachGridLayoutGroup(_appliedPanel.GetComponent<GridLayoutGroup>()));
        _dragCell.DisableDragCell();
    }
    public void UpdateNotApplyedPanel(List<ComponentDefinition> components)
    {
        for (int i = _notAppliedPanel.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(_notAppliedPanel.transform.GetChild(i).gameObject);
        }
        foreach (var item in components)
        {
            var obj = Instantiate(_cellComponentPrefab, _notAppliedPanel.transform);
            obj.GetComponent<Cell>().SetCell(item, _dragCell);
        }
        StartCoroutine(FlachGridLayoutGroup(_notAppliedPanel.GetComponent<GridLayoutGroup>()));
        _dragCell.DisableDragCell();
    }
    private IEnumerator FlachGridLayoutGroup(GridLayoutGroup gridLayoutGroup)
    {
        gridLayoutGroup.enabled = true;
        yield return null;
        yield return null;
        gridLayoutGroup.enabled = false;
    }
}
