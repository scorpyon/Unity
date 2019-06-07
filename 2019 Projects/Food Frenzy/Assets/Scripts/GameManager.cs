using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score;
    public int gameTimeRemaining;

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
        // Do Nothing
    }

    // Update is called once per frame
    void Update()
    {
        // Do Nothing
    }
}
