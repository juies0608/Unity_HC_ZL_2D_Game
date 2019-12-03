using UnityEngine;

public class Bird : MonoBehaviour
{
    [Header("跳躍高度"), Range(50, 2000)]
    public int jump = 100;
    [Header("是否死亡")]
    public bool dead;

    public GameObject goScore, goGM;
    [Header("剛體")]
    public Rigidbody2D r2d;

    /// <summary>
    /// 小雞跳躍功能
    /// </summary>
    private void Jump()
    {
        // 如果 按下 左鍵
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            print("按下左鍵");
            
            goScore.SetActive(true);    // 分數 顯示
            goGM.SetActive(true);       // GM 顯示

            r2d.gravityScale = 1;       // 剛體.重力 = 1
            r2d.Sleep();                // 剛體.睡覺
            r2d.AddForce(new Vector2(0, jump)); //剛體.增加推力
                      //剛體.設定角度
           
        }
        print(r2d.velocity);
        r2d.SetRotation(5 * r2d.velocity.y);
    }

    /// <summary>
    /// 小雞死亡功能
    /// </summary>
    private void Dead()
    {

    }

    /// <summary>
    /// 小雞通過水管
    /// </summary>
    private void PassPipe()
    {

    }

    // 監聽玩家輸入：滑鼠、鍵盤、搖桿
    private void Update()
    {
        Jump();
    }
}
