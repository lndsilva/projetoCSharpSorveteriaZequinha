using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MosaicoSolutions.ViaCep;
//importando biblioteca Myqsl para conectar banco de dados
using MySql.Data.MySqlClient;

namespace SorveteriaZequinha
{
    public partial class frmFuncionarios : Form
    {
        //Criando variáveis para controle do menu
        const int MF_BYCOMMAND = 0X400;
        [DllImport("user32")]
        static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("user32")]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32")]
        static extern int GetMenuItemCount(IntPtr hWnd);

        public frmFuncionarios()
        {
            InitializeComponent();
            //executando o método desabilitar campos
            desabilitarCampos();
        }
        public frmFuncionarios(string nome)
        {
            InitializeComponent();
            //executando o método desabilitar campos
            desabilitarCampos();
            txtNome.Text = nome;
        }

        private void frmFuncionarios_Load(object sender, EventArgs e)
        {
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            int MenuCount = GetMenuItemCount(hMenu) - 1;
            RemoveMenu(hMenu, MenuCount, MF_BYCOMMAND);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal abrir = new frmMenuPrincipal();
            abrir.Show();
            this.Hide();



        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            frmPesquisarFuncionarios abrir = new frmPesquisarFuncionarios();
            abrir.Show();
            this.Hide();
        }
        //desabilitando os componentes
        public void desabilitarCampos()
        {
            txtNome.Enabled = false;
            txtCidade.Enabled = false;
            txtComplemento.Enabled = false;
            txtEmail.Enabled = false;
            txtLogradouro.Enabled = false;
            txtNumero.Enabled = false;
            mskCEP.Enabled = false;
            mskCPF.Enabled = false;
            mskTelefone.Enabled = false;
            cbbEstado.Enabled = false;
            cbbFuncao.Enabled = false;
            cbbUF.Enabled = false;
            dtpDataNascimento.Enabled = false;
            txtBairro.Enabled = false;

            btnCadastrar.Enabled = false;
            btnExcluir.Enabled = false;
            btnAlterar.Enabled = false;
            btnLimpar.Enabled = false;

        }

        //habilitando os componentes
        public void habilitarCampos()
        {
            txtNome.Enabled = true;
            txtCidade.Enabled = true;
            txtComplemento.Enabled = true;
            txtEmail.Enabled = true;
            txtLogradouro.Enabled = true;
            txtNumero.Enabled = true;
            mskCEP.Enabled = true;
            mskCPF.Enabled = true;
            mskTelefone.Enabled = true;
            cbbEstado.Enabled = true;
            cbbFuncao.Enabled = true;
            cbbUF.Enabled = true;
            dtpDataNascimento.Enabled = true;
            txtBairro.Enabled = true;

            btnCadastrar.Enabled = true;
            btnExcluir.Enabled = false;
            btnAlterar.Enabled = false;
            btnLimpar.Enabled = true;

            btnNovo.Enabled = false;
            txtNome.Focus();

        }

        //criando o método busca cep
        public void buscaCEP(string cep)
        {
            var viaCEPService = ViaCepService.Default();
            var endereco = viaCEPService.ObterEndereco(cep);

            txtLogradouro.Text = endereco.Logradouro;
            txtCidade.Text = endereco.Localidade;
            txtBairro.Text = endereco.Bairro;
            cbbEstado.Text = endereco.UF;
            cbbUF.Text = endereco.UF;
            txtComplemento.Text = endereco.Complemento;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            habilitarCampos();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Equals("")
                || txtEmail.Text.Equals("")
                || mskCPF.Text.Equals("   .   .   -")
                || cbbFuncao.Text.Equals("")
                || mskTelefone.Text.Equals("     -")
                || mskCEP.Text.Equals("     -")
                || txtLogradouro.Text.Equals("")
                || txtNumero.Text.Equals("")
                || txtCidade.Text.Equals("")
                || cbbEstado.Text.Equals("")
                || cbbUF.Text.Equals("")
                || txtComplemento.Text.Equals("")
                || txtBairro.Text.Equals(""))
            {
                MessageBox.Show("Favor inserir valores.");
            }
            else
            {

                int resp = cadastrarFuncionarios(txtNome.Text, txtEmail.Text, mskCPF.Text, cbbFuncao.Text,
                    mskTelefone.Text, mskCEP.Text, txtLogradouro.Text, txtNumero.Text,
                    txtCidade.Text, cbbEstado.Text, cbbUF.Text, txtComplemento.Text, txtBairro.Text);

                if (resp == 1)
                {
                    MessageBox.Show("Cadastrado com sucesso!!!");
                    desabilitarCampos();
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar!!!");
                }


            }
        }
        //cadastrar funcionarios
        public int cadastrarFuncionarios(string nome, string email, string cpf,
            string funcao, string telcel, string cep, string logradouro, string numero,
            string cidade, string estado, string uf, string complemento, string bairro
            )
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "insert into tbfuncionarios(nome,email,cpf,funcao,telCel,cep,logradouro,numero,cidade,estado,uf,complemento,bairro)values(@nome,@email,@cpf,@funcao,@telCel,@cep,@logradouro,@numero,@cidade,@estado,@uf,@complemento,@bairro);";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = nome;
            comm.Parameters.Add("@email", MySqlDbType.VarChar, 100).Value = email;
            comm.Parameters.Add("@cpf", MySqlDbType.VarChar, 14).Value = cpf;
            comm.Parameters.Add("@funcao", MySqlDbType.VarChar, 100).Value = funcao;
            comm.Parameters.Add("@telCel", MySqlDbType.VarChar, 10).Value = telcel;
            comm.Parameters.Add("@cep", MySqlDbType.VarChar, 9).Value = cep;
            comm.Parameters.Add("@logradouro", MySqlDbType.VarChar, 100).Value = logradouro;
            comm.Parameters.Add("@numero", MySqlDbType.VarChar, 10).Value = numero;
            comm.Parameters.Add("@cidade", MySqlDbType.VarChar, 100).Value = cidade;
            comm.Parameters.Add("@estado", MySqlDbType.VarChar, 100).Value = estado;
            comm.Parameters.Add("@uf", MySqlDbType.VarChar, 2).Value = uf;
            comm.Parameters.Add("@complemento", MySqlDbType.VarChar, 30).Value = complemento;
            comm.Parameters.Add("@bairro", MySqlDbType.VarChar, 100).Value = bairro;

            comm.Connection = Conexao.obterConexao();

            int resp = comm.ExecuteNonQuery();

            Conexao.fecharConexao();

            return resp;
        }
        private void mskCEP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //executando o método busca cep
                buscaCEP(mskCEP.Text);
                txtNumero.Focus();
            }
        }
    }
}
