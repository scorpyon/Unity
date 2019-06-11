using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score;
    public float gameTimer;

    void Awake()
    {
        MakeSingleton();
    }

    private void MakeSingleton()
    {
        // This guarantees that this is the correctly used Manager (and not a new copy)
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer += Time.deltaTime;

    }

    public void AddToScore(int amount)
    {
        score += amount;
    }

    public void RemoveFromScore(int amount)
    {
        score -= amount;
        if (score < 0) score = 0;
    }
}
