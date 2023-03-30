using UnityEngine;
using TMPro;

public class TeamLeader : MonoBehaviour
{
    public GameManager manager;
    public TMP_Text teammateCountText;
    [SerializeField] int defaultTeammateCount;
    [HideInInspector] public int teammateCount;
    private int finishedTeammateCount;
    private void Start()
    {
        CreateHuman();
        teammateCountText.gameObject.SetActive(false);
        
    }
    void CreateHuman()
    {
        for (int i = 0; i < defaultTeammateCount; i++)
        {
            GameObject human = ObjectGrouper.SharedInstance.GetGroupedObject(Constants.STICKMAN_TAG);
            human.transform.position = transform.position;
            human.transform.SetParent(transform);
            human.GetComponent<Teammate>().JoinTeam();
            human.SetActive(true);
        }
    }
    public void IncreaseFinishedHumanCount()
    {
        finishedTeammateCount++;
        if (finishedTeammateCount == teammateCount)
        {
            GetComponent<BuildTower>().enabled = false;
            manager.Win();
        }
    }
    public void IncreaseHumanCount()
    {
        teammateCount++;
        UpdateText();
    }
    public void DecreaseHumanCount()
    {
        teammateCount--;
        UpdateText();
        if (teammateCount == 0)
        {
            manager.Lose();
        }
    }
    void UpdateText()
    {
        teammateCountText.text = teammateCount.ToString();
    }
    public void TextActiveFalse()
    {
        teammateCountText.gameObject.SetActive(false);
    }
   
    public void OnTextHolder()
    {
   
        teammateCountText.gameObject.SetActive(true);
    }
}
