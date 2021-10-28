using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    class Ability
    {
        public float InitialCost { get; set; }
        public float Cost { get; set; }
        public float CostMultiplier { get; set; }
        public MultiplierTypes CostMultiplierType { get; set; } = MultiplierTypes.DirectMultiplier;
        public float InitialPower { get; set; }
        public float Power { get; set; }
        public float PowerMultiplier { get; set; }
        public MultiplierTypes PowerMultiplierType { get; set; } = MultiplierTypes.DirectMultiplier;
        public int Level { get; set; }
        public string Name { get; set; }
        public enum MultiplierTypes
        {
            DirectMultiplier = 1,
            LinearMultiplier = 2,
            Logarithmic = 3,
            SoftLogarithmic = 4,
        }

        public Ability()
        {

        }
        public void UpgradeLevel()
        {
            Level++;
            SetCurrentCost();
            SetCurrentPower();
        }
        private void SetCurrentCost()
        {
            switch (CostMultiplierType)
            {
                case MultiplierTypes.DirectMultiplier:
                    Cost = InitialCost * Level * CostMultiplier;
                    break;
                case MultiplierTypes.LinearMultiplier:
                    Cost = InitialCost + Level * CostMultiplier;
                    break;
                case MultiplierTypes.Logarithmic:
                    Cost = InitialCost + (float)Math.Pow(CostMultiplier, InitialCost * Level);
                    break;
                case MultiplierTypes.SoftLogarithmic:
                    Cost = InitialCost + (float)Math.Pow(CostMultiplier, CostMultiplier * Level);
                    break;
                default: break;
            }
        }
        private void SetCurrentPower()
        {
            switch (PowerMultiplierType)
            {
                case MultiplierTypes.DirectMultiplier:
                    Power = InitialPower * Level * PowerMultiplier;
                    break;
                case MultiplierTypes.LinearMultiplier:
                    Power = InitialPower + Level * PowerMultiplier;
                    break;
                case MultiplierTypes.Logarithmic:
                    Power = InitialPower + (float)Math.Pow(PowerMultiplier, InitialPower * Level);
                    break;
                case MultiplierTypes.SoftLogarithmic:
                    Power = InitialPower + (float)Math.Pow(PowerMultiplier, PowerMultiplier * Level);
                    break;
                default: break;
            }
        }

        public string GetCostRounded()
        {
            return ((long)(Cost * 100)) / 100 + "";
        }

        public bool IsEnoughMoneyToBuy(float money)
        {
            return money >= Cost;
        }
        public Ability WithInitialCost(float initialCost)
        {
            InitialCost = initialCost;
            Cost = initialCost;
            return this;
        }
        public Ability WithCostMultiplier(float costMultiplier)
        {
            CostMultiplier = costMultiplier;
            return this;
        }
        public Ability WithCostMultiplierType(MultiplierTypes costMultiplierType)
        {
            CostMultiplierType = costMultiplierType;
            return this;
        }
        public Ability WithInitialPower(float initialPower)
        {
            InitialPower = initialPower;
            Power = initialPower;
            return this;
        }
        public Ability WithPowerMultiplier(float powerMultiplier)
        {
            PowerMultiplier = powerMultiplier;
            return this;
        }
        public Ability WithPowerMultiplierType(MultiplierTypes powerMultiplierType)
        {
            PowerMultiplierType = powerMultiplierType;
            return this;
        }
        public Ability WithLevel(int level)
        {
            Level = level;
            return this;
        }
        public Ability WithName(string name)
        {
            Name = name;
            return this;
        }
    }
}
