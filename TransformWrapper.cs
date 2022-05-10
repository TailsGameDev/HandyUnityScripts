using UnityEngine;

public class TransformWrapper
{
    private Transform transform;
    private TransformWrapper parent;

    public TransformWrapper(Transform transform)
    {
        this.transform = transform;
    }

    public Vector3 Position {
        get {
            return transform.position;
        }
        set {
            transform.position = value;
        }
    }
    public Vector3 LocalPosition {
        get {
            return transform.localPosition;
        }
        set {
            transform.localPosition = value;
        }
    }

    public Vector3 EulerAngles {
        get {
            return transform.eulerAngles;
        }
        set {
            transform.eulerAngles = value;
        }
    }
    public Quaternion Rotation 
    {
        get => transform.rotation;
    }

    public void Rotate(float x, float y, float z)
    {
        Vector3 rotation = new Vector3(x, y, z);
        transform.Rotate(rotation);
    }

    public Vector3 LocalScale {
        get {
            return transform.localScale;
        }
        set {
            transform.localScale = value;
        }
    }

    public void SetParent(TransformWrapper parent, bool worldPositionStays = true)
    {
        // TODO: check if default worldPositionStays should really be true
        transform.SetParent(parent == null? null : parent.transform, worldPositionStays: worldPositionStays);
    }
    public TransformWrapper Parent {
        get {
            if (this.parent == null && transform.parent != null)
            {
                this.parent = new TransformWrapper(transform.parent);
            }
            return this.parent;
        }
    }
}
