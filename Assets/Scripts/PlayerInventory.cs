
using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public int collectedEnergy = 0;
    public float playerScale = 2.0f;
    public float scaleDelta = 0.8f;

    public Slider kittenEnergySlider;
    public Text  playerLevelText;
    public Slider playerEnergySlider;
    public GameObject magicDoor;
    public int magicDoorShiningLevel = 3;

    public GameObject secondPlayer;

    public void UpdateEnergySlider()
    {
        int level = getCurrentLevel();
        float value = 100.0f * getCurrentEnergyRatio();

        Debug.Log("level = " + level + " energy slider value:" + value);

        if(level >= magicDoorShiningLevel)
        {
            magicDoor.GetComponent<EnterMushroomDoor>().shiningDoor();
        }

        kittenEnergySlider.value = value;
        playerLevelText.text = "Level : " + level;
        playerEnergySlider.value = value;
    }

    public int getCurrentLevel()
    {
        int level;

        if (collectedEnergy < 4)
        {
            level = 1;
        }
        else if (collectedEnergy < 12)
        {
            level = 2;
        }
        else if (collectedEnergy < 24)
        {
            level = 3;
        }
        else if (collectedEnergy < 40)
        {
            level = 4;
        }
        else if (collectedEnergy < 60)
        {
            level = 5;
        }
        else if (collectedEnergy < 84)
        {
            level = 6;
        }
        else if (collectedEnergy < 112)
        {
            level = 7;
        }
        else if (collectedEnergy < 144)
        {
            level = 8;
        }
        else
        {
            level = 9;
        }

        playerScale = 2.0f + (level - 1) * scaleDelta;
        return level;

    }

    private float getCurrentEnergyRatio()
    {
        if (collectedEnergy < 4)
        {
            return collectedEnergy / 4.0f;
        }
        else if (collectedEnergy < 12)
        {
            return (collectedEnergy - 4) / 8.0f;
        }
        else if (collectedEnergy < 24)
        {
            return (collectedEnergy - 12) / 12.0f;
        }
        else if (collectedEnergy < 40)
        {
            return (collectedEnergy - 24) / 16.0f;
        }
        else if (collectedEnergy < 60)
        {
            return (collectedEnergy - 40) / 20.0f;
        }
        else if (collectedEnergy < 84)
        {
            return (collectedEnergy - 60) / 24.0f;
        }
        else if (collectedEnergy < 112)
        {
            return (collectedEnergy - 84) / 28.0f;
        }
        else if (collectedEnergy < 144)
        {
            return (collectedEnergy - 112) / 32.0f;
        }
        else
        {
            float ratio = (collectedEnergy - 144) / 36.0f;
            return ratio > 1.0f ? 1.0f : ratio;
        }
    }

    private void OnDestroy()
    {

        Instantiate(secondPlayer, transform.position, transform.rotation);
    }
}
