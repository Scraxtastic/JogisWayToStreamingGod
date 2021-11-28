using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveToPointOnClick : MonoBehaviour
{
    public GameObject ComponentToMove;
    public Vector2 PositionToMoveTo;
    public bool UseStartPosition = false;
    public bool MoveOnStart = false;

    private bool _firstRun = true;
    // Start is called before the first frame update
    void Start()
    {
        if (UseStartPosition)
        {
            Vector2 currentPos = ComponentToMove.transform.position;
            PositionToMoveTo = new Vector2(currentPos.x, currentPos.y);
        }
        Button button = GetComponent<Button>();
        if (button) button.onClick.AddListener(MoveToPoint);
    }

    private void Update()
    {
        if (_firstRun && MoveOnStart)
        {
            _firstRun = false;
            MoveToPoint();
        }
    }

    void MoveToPoint()
    {
        ComponentToMove.transform.position = PositionToMoveTo;
    }
}
