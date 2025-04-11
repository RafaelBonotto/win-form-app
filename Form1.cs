namespace WinFormsAppLogin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsuario.Text.Equals("Rafael") && txtSenha.Text.Equals("123@"))
                {
                    // Usu�rio v�lido -> segue o fluxo para pr�ximo Form (MenuRestrito)
                    var menuRestrito = new MenuRestrito();
                    menuRestrito.Show();

                    this.Visible = false; //(this -> Form1 classe/form atual) - (Visible = False Impede a visibilidade do form atual)
                }
                else
                {
                    MessageBox.Show("Usu�rio ou Senha Inv�lidos",
                                    "Desculpe",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);

                    txtSenha.Text = string.Empty; // Limpa o text box senha
                    txtUsuario.Text = string.Empty; // Limpa o text box usu�rio
                    txtUsuario.Focus(); // Ir� jogar o cursor do mouse para o text box usu�rio
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro inesperado",
                                    ex.Message,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                throw;
            }
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            txtUsuario.BackColor = Color.LightYellow;
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            txtUsuario.BackColor = Color.White;
        }

        private void txtSenha_Enter(object sender, EventArgs e)
        {
            txtUsuario.BackColor = Color.LightYellow;
        }

        private void txtSenha_Leave(object sender, EventArgs e)
        {
            txtUsuario.BackColor = Color.White;
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            int teclaDigitadaInt = (int)e.KeyChar;
            int teclaBackspaceInt = 08; // Microsoft Docs / Keys Enum

            if (!char.IsLetterOrDigit(e.KeyChar) && teclaDigitadaInt != teclaBackspaceInt)
            {
                e.Handled = true; // Tartando evento, desconsidera o carcter digitado nesse caso
                
                MessageBox.Show("Digite apenas letras ou n�meros",
                                "Caracter inv�lido",                                
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                txtUsuario.SelectionStart = 0; // Seleciona o texto a partir do caracter 0
                txtUsuario.SelectionLength = txtUsuario.Text.Length; // Seleciona o texto at� o final (Length)

                txtUsuario.Focus(); // Define o foco obrigat�rio para esse campo
            }
        }
    }
}
