using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

/// <summary>
/// Every "drag and drop" item must contain this script
/// </summary>
[RequireComponent(typeof(Image))]
public class DragAndDropItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    static public DragAndDropItem draggedItem;                                      // Item that is dragged now
    static public GameObject icon;                                                  // Icon of dragged item
	static public GameObject text;
	static public GameObject iconText;
	static public DragAndDropCell sourceCell;                                       // From this cell dragged item is

    public delegate void DragEvent(DragAndDropItem item);
    static public event DragEvent OnItemDragStartEvent;                             // Drag start event
    static public event DragEvent OnItemDragEndEvent;                               // Drag end event

    /// <summary>
    /// This item is dragged
    /// </summary>
    /// <param name="eventData"></param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        sourceCell = GetComponentInParent<DragAndDropCell>();                       // Remember source cell
        draggedItem = this;                                                         // Set as dragged item
		icon = new GameObject("Icon");                                              // Create object for item's icon
		text = transform.FindChild("Text").gameObject;
		iconText = Instantiate (text, icon.transform);								// Create object for item's icon text
		iconText.GetComponent<Text> ().raycastTarget = false;						// Disable icon text's raycast for correct drop handling
		Canvas canvas = GetComponentInParent<Canvas>();                             // Get parent canvas
		Image image = icon.AddComponent<Image>();
        image.sprite = GetComponent<Image>().sprite;
		image.type = Image.Type.Sliced;												// Set image type to sliced for proper UI scaling
        image.raycastTarget = false;                                                // Disable icon's raycast for correct drop handling
		Color color = GetComponent<Image>().color;
		image.color = color;
		RectTransform iconRect = icon.GetComponent<RectTransform>();
        // Set icon's scale and dimensions
		iconRect.localScale = new Vector3 ((canvas.GetComponent<RectTransform>().localScale.x * transform.parent.parent.GetComponentInParent<RectTransform>().localScale.x),
											(canvas.GetComponent<RectTransform>().localScale.y * transform.parent.parent.GetComponentInParent<RectTransform>().localScale.y),
											(canvas.GetComponent<RectTransform>().localScale.z * transform.parent.parent.GetComponentInParent<RectTransform>().localScale.z));
        iconRect.sizeDelta = new Vector2(   GetComponent<RectTransform>().sizeDelta.x,
                                            GetComponent<RectTransform>().sizeDelta.y);
		// Rescale icon text
		iconText.GetComponent<RectTransform> ().localScale = new Vector3 (1f, 1f, 1f);
		iconText.GetComponent<RectTransform> ().localPosition = new Vector3 (0, 0, 0);
		if (canvas != null)
        {
            // Display on top of all GUI (in parent canvas)
            icon.transform.SetParent(canvas.transform, true);                       // Set canvas as parent
            icon.transform.SetAsLastSibling();                                      // Set as last child in canvas transform
        }
        if (OnItemDragStartEvent != null)
        {
            OnItemDragStartEvent(this);                                             // Notify all about item drag start
        }
    }

    /// <summary>
    /// Every frame on this item drag
    /// </summary>
    /// <param name="data"></param>
    public void OnDrag(PointerEventData data)
    {
        if (icon != null)
        {
            icon.transform.position = Input.mousePosition;                          // Item's icon follows to cursor
        }
    }

    /// <summary>
    /// This item is dropped
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        if (icon != null)
        {
            Destroy(icon);                                                          // Destroy icon on item drop
        }
        MakeVisible(true);                                                          // Make item visible in cell
        if (OnItemDragEndEvent != null)
        {
            OnItemDragEndEvent(this);                                               // Notify all cells about item drag end
        }
        draggedItem = null;
        icon = null;
        sourceCell = null;
    }

    /// <summary>
    /// Enable item's raycast
    /// </summary>
    /// <param name="condition"> true - enable, false - disable </param>
    public void MakeRaycast(bool condition)
    {
        Image image = GetComponent<Image>();
        if (image != null)
        {
            image.raycastTarget = condition;
        }
    }

    /// <summary>
    /// Enable item's visibility
    /// </summary>
    /// <param name="condition"> true - enable, false - disable </param>
    public void MakeVisible(bool condition)
    {
        GetComponent<Image>().enabled = condition;
		GetComponentInChildren<Text> ().enabled = condition;
    }
}
