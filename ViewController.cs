using System;
using System.Windows.Forms;


namespace ToDo.Controllers
{
    public class ViewController
    {
        public Panel ViewContainer = new Panel();

        public ViewController()
        {
            this.ViewContainer.Name = "ViewContainer";
        }

        /*
            Controla qual módulo organizacional vai ser exibido no painel
            */
        public void LoadView(UserControl newView)
        {
            // Garante que o painel de módulos organizacionais esteja vazio
            this.ViewContainer.Controls.Clear();

            // Adiciona o novo módulo organizacional ao painel
            newView.Dock = DockStyle.Fill;
            this.ViewContainer.Controls.Add(newView);
        }
    }
}


