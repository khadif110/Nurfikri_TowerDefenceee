using UnityEngine;

public class DragDrop : MonoBehaviour
{
 [HideInInspector]
 public Vector3 screenPoint;
 [HideInInspector]
 public Vector3 offset;
 [HideInInspector]
    public int cost;
 [HideInInspector]
    public bool follow = true;

    private void Update()
    {
        if (follow)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
            if (Input.GetMouseButton(0))
            {
                if (transform.position.x < 0 && transform.position.y > -2f)
                {
                    follow = false;
                    Data.coin -= cost;
                    foreach (Behaviour childComponent in GetComponentsInChildren<Behaviour>())
                    childComponent.enabled = true;
                }
                else
                {
                    Destroy(gameObject);
                    Debug.Log("Meletakan area yang tidak di izinkan");
                }
            }
        }
    }
}
