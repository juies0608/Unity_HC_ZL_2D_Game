using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("目前分數")]
    public int score;
    [Header("最高分數")]
    public int scoreHeight;
    [Header("水管")]
    public GameObject pipe; // GameObject 可以存放預製物以及場景上的物件
    [Header("介面群組")]
    public GameObject goUI;
    [Header("分數介面")]
    public Text textScore;
    public Text textHeight;
    public Ground Ground;
    /// <summary>
    /// 生成水管功能
    /// </summary>
    public void SpawnPipe()
    {
        // 因為有繼承此類別才可簡寫
        // Object.Instantiate(pipe);

        // 浮點數 = 隨機.靜態方法(最小，最大)
        float y = Random.Range(-1.1f, 1.9f);

        // 三維向量 Vector3 - x, y, z
        Vector3 pos = new Vector3(6f, y, 0);

        // 四元數 Quaternion - x, y, z, w
        Quaternion rot = new Quaternion(0, 0, 0, 0);

        // 生成(物件，座標，角度)
        Instantiate(pipe, pos, rot);
    }

    /// <summary>
    /// 加分功能
    /// </summary>
    /// <param name="add">要添加的分數</param>
    public void AddScore(int add)
    {
        score += add;
        //textScore.text = score + "";
        textScore.text = score.ToString();  // 整數.轉字串()

        SetHeightScore();
    }

    /// <summary>
    /// 設定最高分數
    /// </summary>
    private void SetHeightScore()
    {
        // 如果目前分數 > 最高分數
        if (score > scoreHeight)
        {
            // 最高分數 = 目前分數
            scoreHeight = score;

            PlayerPrefs.SetInt("最高分數", scoreHeight);
        }

        textHeight.text = scoreHeight.ToString();
    }

    /// <summary>
    /// 遊戲結束
    /// </summary>
    public void GameOver()
    {
        goUI.SetActive(true);
        Ground.speed = 0;
    }

    private void Start()
    {
        // 延遲重複調用方法("方法名稱"，延遲時間，重複頻率)
        InvokeRepeating("SpawnPipe", 0, 1.5f);
        scoreHeight = PlayerPrefs.GetInt("最高分數");
        textHeight.text = scoreHeight.ToString();
    }
}
