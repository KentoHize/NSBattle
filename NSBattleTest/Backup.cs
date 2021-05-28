using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Aritiafel.Characters.Heroes;

namespace NSBattleTest
{
    [TestClass]
    public class Backup
    {
        [TestMethod]
        public void BackupProject()
        {
            Tina.SaveProject(ProjectChoice.NSBattle);
        }

        [TestMethod]
        public void BackupAritiafel()
        {
            Tina.SaveProject();
        }
    }
}
