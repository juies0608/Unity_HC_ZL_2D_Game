using UnityEngine;

public class Ground : MonoBehaviour
{
    //static 靜態  隱藏
    //此類別共用 包含子類別
    [Header("速度"), Range(0, 100)]
    public static float speed = 10.5f;
    
    [Header("變形")]
    public Transform tran;

    /// <summary>
    /// 地板移動功能
    /// </summary>
    private void Move()
    {
        // Time.deltaTime 一幀的時間
        tran.Translate(-speed * Time.deltaTime, 0, 0);
    }
    
    private void Update()
    {
        Move();
    }
}
