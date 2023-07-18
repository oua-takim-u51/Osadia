using UnityEngine;

public class Points : MonoBehaviour
{
    public static int enemiesKilled = 0;
    public static int arcadiumCollected = 0;
    public static int timePassed = 0;
    public static int itemCollected = 0;

    void UpdateTime()
    {
        timePassed = (int)Time.fixedTime;
    }
    private void Update()
    {
        UpdateTime();
        Debug.Log(timePassed);
    }
    public static int GetPoints()
    {
        int score = enemiesKilled * 50 + arcadiumCollected * 20 + timePassed * 2 + itemCollected * 30;
        return score;
    }
}