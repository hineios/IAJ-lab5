﻿using System.Collections.Generic;
using Assets.Scripts.GameManager;

namespace Assets.Scripts.IAJ.Unity.DecisionMaking.GOB
{
    //class that represents a world model that corresponds to the current state of the world,
    //all required properties and goals are stored inside the game manager
    public class CurrentStateWorldModel : WorldModel
    {
        private GameManager.GameManager GameManager { get; set; }
        private Dictionary<string, Goal> Goals { get; set; } 

        public CurrentStateWorldModel(GameManager.GameManager gameManager, List<Action> actions, List<Goal> goals) : base(actions)
        {
            this.GameManager = gameManager;
            this.Parent = null;
            this.Goals = new Dictionary<string, Goal>();

            foreach (var goal in goals)
            {
                this.Goals.Add(goal.Name,goal);
            }
        }

        public void Initialize()
        {
            this.ActionEnumerator.Reset();
        }

        public override object GetProperty(string propertyName)
        {
            if (propertyName.Equals(Properties.MANA)) return this.GameManager.characterData.Mana;

            if (propertyName.Equals(Properties.XP)) return this.GameManager.characterData.XP;

            if (propertyName.Equals(Properties.MAXHP)) return this.GameManager.characterData.MaxHP;

            if (propertyName.Equals(Properties.HP)) return this.GameManager.characterData.HP;

            if (propertyName.Equals(Properties.MONEY)) return this.GameManager.characterData.Money;

            if (propertyName.Equals(Properties.TIME)) return this.GameManager.characterData.Time;

            if (propertyName.Equals(Properties.LEVEL)) return this.GameManager.characterData.Level;

            if (propertyName.Equals(Properties.POSITION))
                return this.GameManager.characterData.CharacterGameObject.transform.position;

            return true;
        }

        public override float GetGoalValue(string goalName)
        {
            return this.Goals[goalName].InsistenceValue;
        }

        public override void SetGoalValue(string goalName, float goalValue)
        {
            //this method does nothing, because you should not directly set a goal value of the CurrentStateWorldModel
        }

        public override void SetProperty(string propertyName, object value)
        {
            //this method does nothing, because you should not directly set a property of the CurrentStateWorldModel
        }
    }
}
