using System.Windows.Forms;
using ToDo.Controllers;

namespace ToDo
{
    public partial class Form1 : Form
    {
        private int numberCount = 0;

        private readonly ViewController viewController = new();

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var dados = new
            {
                Nome = "João",
                Idade = 30
            };

            // Criptografar e salvar no arquivo
            string dadosCriptografados = CriptografiaJson.Criptografar(dados);
            File.WriteAllText(this.archivePath, dadosCriptografados);

            // Ler e descriptografar
            string conteudo = File.ReadAllText(this.archivePath);
            var conteudoDescriptografado = CriptografiaJson.Descriptografar<dynamic>(conteudo);

            MessageBox.Show(
                $"Criptografado:\n{conteudo}\n\nDescriptografado:\nNome: {conteudoDescriptografado.Nome}, Idade: {conteudoDescriptografado.Idade}"
            );
        }


        /*
         POMODORO

           
         */
        private void button1_Click_1(object sender, EventArgs e)
        {
            viewController.LoadView(new Pomodoro());
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
