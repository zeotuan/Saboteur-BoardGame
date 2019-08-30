
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Component
{
    private static T instance;
    // Start is called before the first frame update
   
    public static T Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<T>();
                if(instance  == null)
                {
                    var obj = new GameObject();
                    instance = obj.AddComponent<T>();
                    obj.hideFlags = HideFlags.HideAndDontSave;
                }
            }
            return instance;
        }
        set
        {
            instance = value;
        }
    }

    public virtual void Awake()
    {
        DontDestroyOnLoad(this);
        if (instance == null)
        {
            instance = this as T;

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
