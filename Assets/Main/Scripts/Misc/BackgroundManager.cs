using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public List<Sprite> sprites = new List<Sprite>();

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        if (PlayerPrefs.HasKey(PrefNames.currentTime))
        {
            sp.sprite = sprites[PlayerPrefs.GetInt(PrefNames.currentTime) % sprites.Count];
        }
        else
        {
            sp.sprite = sprites[0];
        }
    }
}
