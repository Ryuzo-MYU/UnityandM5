using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField, Tooltip("可動範囲")] float rotatableRigion;
    [SerializeField, Tooltip("反転するか")] bool isReverced;

    [Header("Components")]
    [SerializeField] AccelarationDataReceiver receiver;

    //--------------------------------------------------

    private void Awake()
    {
        // 反転させる場合、-1をかける
        if (isReverced)
        {
            rotatableRigion *= -1;
        }
    }

    // 移動
    void FixedUpdate()
    {
        var euler = receiver.Accelaration * rotatableRigion;

        transform.rotation = Quaternion.Euler(euler.y, euler.x, 0);
    }
}

