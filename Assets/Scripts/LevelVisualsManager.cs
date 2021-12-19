using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelVisualsManager : MonoBehaviour
{
    public float BackgroundScrollSpeed = 5;

    public RectTransform BackgroundTransform;
    public RectTransform LeftSideTransform;
    public RectTransform RightSideTransform;

    RectTransform backgroundDuplicate;
    Image backgroundImage;
    Image backgroundDuplicateImage;

    Sprite[] BackgroundSprites { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        LoadComponents();

        //TODO: This is for testing purposes only
        LoadAssets(new LevelAssets()
        {
            BackgroundImagePaths = new string[] { "Sprites/UI/Themes/Mansion/mansionBackground" },
            RightSideBackgroundPath = "Sprites/UI/Themes/Mansion/mansionSideBackground"
        });

    }

    void LoadComponents()
    {
        backgroundImage = BackgroundTransform.GetComponent<Image>();
        backgroundDuplicate = (RectTransform)Instantiate(BackgroundTransform.gameObject, BackgroundTransform.parent).transform;
        backgroundDuplicateImage = backgroundDuplicate.GetComponent<Image>();
        backgroundDuplicate.anchoredPosition += new Vector2(0, (backgroundDuplicate.rect.height * backgroundDuplicate.localScale.y) - 2);
    }

    public void LoadAssets(LevelAssets assets)
    {
        Sprite[] backgroundSprites = new Sprite[assets.BackgroundImagePaths.Length];
        for (int i = 0; i < assets.BackgroundImagePaths.Length; i++)
        {
            backgroundSprites[i] = Resources.Load<Sprite>(assets.BackgroundImagePaths[i]);
        }
        BackgroundSprites = backgroundSprites;

        RightSideTransform.GetComponent<Image>().sprite = Resources.Load<Sprite>(assets.RightSideBackgroundPath);
        if (assets.LeftSideBackgroundPath != null)
        {
            LeftSideTransform.GetComponent<Image>().sprite = Resources.Load<Sprite>(assets.LeftSideBackgroundPath);
            LeftSideTransform.localScale = new Vector3(2, LeftSideTransform.localScale.y, LeftSideTransform.localScale.z);
        }
        else
        {
            LeftSideTransform.GetComponent<Image>().sprite = Resources.Load<Sprite>(assets.RightSideBackgroundPath);
            LeftSideTransform.localScale = new Vector3(-2, LeftSideTransform.localScale.y, LeftSideTransform.localScale.z);
        }

        backgroundImage.sprite = GetBackground();
        backgroundDuplicateImage.sprite = GetBackground();
    }

    Sprite GetBackground()
    {
        if (BackgroundSprites.Length == 1) return BackgroundSprites[0];
        if (BackgroundSprites.Length > 1)
        {
            var randomNum = Random.Range(0, BackgroundSprites.Length);
            return BackgroundSprites[randomNum];
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateBackground();
    }

    void UpdateBackground()
    {
        var scrollSpeed = -BackgroundScrollSpeed * Time.deltaTime;
        //Background 1
        BackgroundTransform.position += new Vector3(0, scrollSpeed);
        if(BackgroundTransform.anchoredPosition.y < -1200)
        {
            BackgroundTransform.anchoredPosition += new Vector2(0, (BackgroundTransform.rect.height * BackgroundTransform.localScale.y * 2) - 2);
        }

        //Background 2
        backgroundDuplicate.position += new Vector3(0, scrollSpeed);
        if (backgroundDuplicate.anchoredPosition.y < -1200)
        {
            backgroundDuplicate.anchoredPosition += new Vector2(0, (backgroundDuplicate.rect.height * backgroundDuplicate.localScale.y * 2) - 2);
        }
    }
}
