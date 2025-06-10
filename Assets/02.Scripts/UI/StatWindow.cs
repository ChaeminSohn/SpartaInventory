using System;
using _02.Scripts.Event;
using _02.Scripts.Manager;
using _02.Scripts.Player;
using TMPro;
using UnityEngine.UI;

namespace _02.Scripts.UI
{
    public class StatWindow : BaseWindow
    {
        private PlayerStat stat;
        public Button closeButton;
        public TextMeshProUGUI nameText;
        public TextMeshProUGUI classText;
        public TextMeshProUGUI guildText;
        public TextMeshProUGUI fameText;
        public TextMeshProUGUI healthText;
        public TextMeshProUGUI manaText;
        public TextMeshProUGUI attackText;
        public TextMeshProUGUI defenseText;
        public TextMeshProUGUI speedText;
        public TextMeshProUGUI jumpText;
        public override UIType UIType => UIType.StatWindow;
        public override void OnOpen()
        {
            if (stat == null)
            {
                stat = GameManager.Instance.PlayerStat;
            }

            stat.StatChangeEvent += UpdateStat;
            closeButton.onClick.AddListener(() =>
            {
                UIManager.Instance.CloseWindow(UIType.StatWindow);
            });
            UpdateBaseInfo();
            UpdateStat();
        }

        public override void OnClose()
        {
            closeButton.onClick.RemoveAllListeners();
            stat.StatChangeEvent -= UpdateStat;
        }

        private void UpdateBaseInfo()    //기본 정보 업데이트
        {
            nameText.text = stat.playerData.name;
            classText.text = stat.playerData.classType.ToString();
            guildText.text = stat.playerData.guild;
            fameText.text = stat.playerData.fame.ToString();
        }

        private void UpdateStat()       //스탯 업데이트
        {
            healthText.text = $"{stat.CurrentHealth} / {stat.TotalHealth}";
            manaText.text = $"{stat.CurrentMana} / {stat.TotalMana}";
            attackText.text = $"{stat.TotalAttack}";
            defenseText.text = $"{stat.TotalDefense}";
            speedText.text = $"{stat.TotalSpeed}";
            jumpText.text = $"{stat.TotalJump}";
        }
    }
}
