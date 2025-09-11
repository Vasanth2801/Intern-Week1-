using UnityEngine;

public class SingletonPratice : MonoBehaviour
{
    public static SingletonPratice  instance{ get; private set; }

    private void Awake()
    {
        if ((instance != null && instance!= this))
        {
            Destroy(gameObject );
        }
        else
        {
                       instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
