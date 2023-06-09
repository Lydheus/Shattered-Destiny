using UnityEngine;
using UnityEngine.UI;
using TMPro;
using SD.Primitives;

namespace SD.CharacterSystem
{
    public class UICharacterSheet : MonoBehaviour
    {
        [SerializeField] private Image characterPortrait;
        [SerializeField] private TMP_Text ageText;
        [SerializeField] private TMP_Text wellBeingText;

        [Space]

        [SerializeField] private Image healthBar;
        [SerializeField] private Image staminaBar;
        [SerializeField] private Image actionPointBar;

        [Header("Attributes")]
        [SerializeField] private TMP_Text[] attributeText;
        [SerializeField] private TMP_Text[] attributeXPText;
        [SerializeField] private Image[] attributeXPBar;

        [Header("Influence & Reputation")]
        [SerializeField] private TMP_Text[] influenceText;
        [SerializeField] private TMP_Text[] reputationText;
        [SerializeField] private IntReference[] influenceRefs;
        [SerializeField] private IntReference[] reputationRefs;

        public void DisplayValues(CharacterSheet character)
        {
            DisplayAttributes(character);
            DisplayInfluenceAndReputation();
        }

        private void DisplayAttributes(CharacterSheet character)
        {
            for (int i = 0; i < character.Attributes.Length; i++)
            {
                attributeText[i].text = ((Attribute)i).ToString() + " :" + character.Attributes[i].Value;
                attributeXPText[i].text = "XP: " + character.Attributes[i].XP + " / " + character.Attributes[i].XPToNextLevel;
                attributeXPBar[i].fillAmount = character.Attributes[i].XP / character.Attributes[i].XPToNextLevel;
            }
        }

        private void DisplayInfluenceAndReputation()
        {
            for (int i = 0; i < influenceText.Length; i++)
            {
                influenceText[i].text = ((Faction)i).ToString() + ": " + influenceRefs[i].Value;
            }

            for (int i = 0; i < reputationText.Length; i++)
            {
                reputationText[i].text = ((Faction)i).ToString() + ": " + reputationRefs[i].Value;
            }
        }
    }
}

public enum Faction
{
    Green,
    Yellow,
    Red,
    Purple,
}