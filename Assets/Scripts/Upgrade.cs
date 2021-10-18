using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    class Upgrade
    {
        public float InitialCost { get; set; }
        public float CostMultiplier { get; set; }
        public int Level { get; set; }

        public Upgrade()
        {

        }

        public Upgrade WithInitialCost(float initialCost)
        {
            InitialCost = initialCost;
            return this;
        }
        public Upgrade WithCostMultiplier (float costMultiplier)
        {
            CostMultiplier = costMultiplier;
            return this;
        }
        public Upgrade WithLevel(int level)
        {
            Level = level;
            return this;
        }
    }
}
