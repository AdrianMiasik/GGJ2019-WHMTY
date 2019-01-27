using UnityEngine;

public class ShellDecorator : MonoBehaviour
{
    private bool isAttached;
    private bool isFollowingMouse;

    private void LateUpdate()
    {
        if (isFollowingMouse)
        {
            transform.position = Input.mousePosition;
        }
    }

    public void OnMouseDown()
    {
        if (isAttached) return;

        isFollowingMouse = true;
    }

    public void OnMouseUp()
    {
        isFollowingMouse = false;
        if (IsItemOnSnapPoint())
        {

        }
        // TODO: Check if transform.position is within margin of error of shell's snap position
        // TODO: If so, attach it to Shell
        // TODO: else, return it to conveyer belt or destory?
    }

    private bool IsItemOnSnapPoint()
    {
        // TODO: Compare snap point's transform and this.transform
        // TODO: If within threshold, snap
        return false;
    }
}
