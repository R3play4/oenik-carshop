namespace CarShop.Console.MenuItems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CarShop.Data;

    internal class DeleteConnection : MenuItem
    {
        public DeleteConnection(string name, string command) 
            : base(name, command)
        {
        }

        // Ez majd egy groupolt megjelnitéssel fog törölni.
        public override void ExecuteMenuAction()
        {
            int selection = this.ChooseConnection();
            this.LogicContact.DeleteConnection(selection);
        }

        private int ChooseConnection()
        {
            IEnumerable<object> modelsExtra = this.LogicContact.GetExtraModelLogic();

            foreach (var item in modelsExtra)
            {
                Console.WriteLine(item);
            }

            int selected = 0;
            Console.WriteLine("Select the id of the connection that you would like to delete");

            try
            {
                selected = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return selected;
        }
    }
}
